using Application.Features.BorrowedMaterials.Constants;
using Application.Features.BorrowedMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BorrowedMaterials.Constants.BorrowedMaterialsOperationClaims;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdateBorrowedMaterialCommand : IRequest<UpdatedBorrowedMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }

    public string[] Roles => [Admin, Write, BorrowedMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBorrowedMaterials"];

    public class UpdateBorrowedMaterialCommandHandler : IRequestHandler<UpdateBorrowedMaterialCommand, UpdatedBorrowedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;

        public UpdateBorrowedMaterialCommandHandler(IMapper mapper, IBorrowedMaterialRepository borrowedMaterialRepository,
                                         BorrowedMaterialBusinessRules borrowedMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
        }

        public async Task<UpdatedBorrowedMaterialResponse> Handle(UpdateBorrowedMaterialCommand request, CancellationToken cancellationToken)
        {
            BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _borrowedMaterialBusinessRules.BorrowedMaterialShouldExistWhenSelected(borrowedMaterial);
            borrowedMaterial = _mapper.Map(request, borrowedMaterial);

            await _borrowedMaterialRepository.UpdateAsync(borrowedMaterial!);

            UpdatedBorrowedMaterialResponse response = _mapper.Map<UpdatedBorrowedMaterialResponse>(borrowedMaterial);
            return response;
        }
    }
}