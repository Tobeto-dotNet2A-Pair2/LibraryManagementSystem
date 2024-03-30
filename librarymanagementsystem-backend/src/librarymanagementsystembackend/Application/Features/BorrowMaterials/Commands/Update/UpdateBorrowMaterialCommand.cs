using Application.Features.BorrowMaterials.Constants;
using Application.Features.BorrowMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BorrowMaterials.Constants.BorrowMaterialsOperationClaims;

namespace Application.Features.BorrowMaterials.Commands.Update;

public class UpdateBorrowMaterialCommand : IRequest<UpdatedBorrowMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid MemberId { get; set; }

    public string[] Roles => [Admin, Write, BorrowMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBorrowMaterials"];

    public class UpdateBorrowMaterialCommandHandler : IRequestHandler<UpdateBorrowMaterialCommand, UpdatedBorrowMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowMaterialRepository _borrowMaterialRepository;
        private readonly BorrowMaterialBusinessRules _borrowMaterialBusinessRules;

        public UpdateBorrowMaterialCommandHandler(IMapper mapper, IBorrowMaterialRepository borrowMaterialRepository,
                                         BorrowMaterialBusinessRules borrowMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowMaterialRepository = borrowMaterialRepository;
            _borrowMaterialBusinessRules = borrowMaterialBusinessRules;
        }

        public async Task<UpdatedBorrowMaterialResponse> Handle(UpdateBorrowMaterialCommand request, CancellationToken cancellationToken)
        {
            BorrowMaterial? borrowMaterial = await _borrowMaterialRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _borrowMaterialBusinessRules.BorrowMaterialShouldExistWhenSelected(borrowMaterial);
            borrowMaterial = _mapper.Map(request, borrowMaterial);

            await _borrowMaterialRepository.UpdateAsync(borrowMaterial!);

            UpdatedBorrowMaterialResponse response = _mapper.Map<UpdatedBorrowMaterialResponse>(borrowMaterial);
            return response;
        }
    }
}