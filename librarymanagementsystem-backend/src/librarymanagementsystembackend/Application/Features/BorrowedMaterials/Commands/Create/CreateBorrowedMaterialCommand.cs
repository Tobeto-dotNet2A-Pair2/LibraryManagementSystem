using Application.Features.BorrowedMaterials.Constants;
using Application.Features.BorrowedMaterials.Dtos;
using Application.Features.BorrowedMaterials.Rules;
using Application.Features.MaterialCopies.Rules;
using Application.Features.Members.Rules;
using Application.Services.MaterialCopies;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BorrowedMaterials.Constants.BorrowedMaterialsOperationClaims;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommand : IRequest<CreatedBorrowedMaterialResponse>, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }

    public class CreateBorrowedMaterialCommandHandler : IRequestHandler<CreateBorrowedMaterialCommand, CreatedBorrowedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;
        private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;
        private readonly MemberBusinessRules _memberBusinessRules;
        private readonly IMaterialCopyService _materialCopyService;

        public CreateBorrowedMaterialCommandHandler(IMapper mapper, 
            IBorrowedMaterialRepository borrowedMaterialRepository,
            BorrowedMaterialBusinessRules borrowedMaterialBusinessRules, 
            MaterialCopyBusinessRules materialCopyBusinessRules, 
            IMaterialCopyService materialCopyService, 
            MemberBusinessRules memberBusinessRules)
        {
            _mapper = mapper;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
            _materialCopyBusinessRules = materialCopyBusinessRules;
            _materialCopyService = materialCopyService;
            _memberBusinessRules = memberBusinessRules;
        }

        public async Task<CreatedBorrowedMaterialResponse> Handle(CreateBorrowedMaterialCommand request, CancellationToken cancellationToken)
        {
            #region BusinessRules
            
            await _borrowedMaterialBusinessRules.MemberDoesNotHaveSameMaterialAtTheSameTime(request.MemberId, request.MaterialCopyId, cancellationToken);
            await _memberBusinessRules.MemberShouldHaveNoDebt(request.MemberId, cancellationToken);
            await _materialCopyBusinessRules.MaterialCopyIsShouldReservableWhenBorrowed(request.MaterialCopyId,cancellationToken);

            #endregion
         
            #region Checks And Insert
            GetForBorrowDto materialWithCopy = await _materialCopyService.GetForBorrow(request.MaterialCopyId);
            if (materialWithCopy is null) //TODO : Message have to replace with localization service.
                throw new Exception("The requested material can not be found");

            var borrowedMaterial = _mapper.Map<BorrowedMaterial>(request);
            borrowedMaterial.ReturnDate = DateTime.UtcNow.AddDays(materialWithCopy.BorrowDay);
            await _borrowedMaterialRepository.AddAsync(borrowedMaterial);
            
            #endregion

            await _materialCopyService.UpdateAfterBorrow(request.MaterialCopyId);
            
            #region Response
            
            var response = _mapper.Map<CreatedBorrowedMaterialResponse>(borrowedMaterial);
            response.PunishmentAmount = materialWithCopy.PunishmentAmount;

            return response;
            #endregion
        }
    }
}