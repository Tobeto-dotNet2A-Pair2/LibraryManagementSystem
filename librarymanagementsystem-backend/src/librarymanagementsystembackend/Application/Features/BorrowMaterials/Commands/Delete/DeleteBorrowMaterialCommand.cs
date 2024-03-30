using Application.Features.BorrowMaterials.Constants;
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

namespace Application.Features.BorrowMaterials.Commands.Delete;

public class DeleteBorrowMaterialCommand : IRequest<DeletedBorrowMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BorrowMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBorrowMaterials"];

    public class DeleteBorrowMaterialCommandHandler : IRequestHandler<DeleteBorrowMaterialCommand, DeletedBorrowMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowMaterialRepository _borrowMaterialRepository;
        private readonly BorrowMaterialBusinessRules _borrowMaterialBusinessRules;

        public DeleteBorrowMaterialCommandHandler(IMapper mapper, IBorrowMaterialRepository borrowMaterialRepository,
                                         BorrowMaterialBusinessRules borrowMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowMaterialRepository = borrowMaterialRepository;
            _borrowMaterialBusinessRules = borrowMaterialBusinessRules;
        }

        public async Task<DeletedBorrowMaterialResponse> Handle(DeleteBorrowMaterialCommand request, CancellationToken cancellationToken)
        {
            BorrowMaterial? borrowMaterial = await _borrowMaterialRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _borrowMaterialBusinessRules.BorrowMaterialShouldExistWhenSelected(borrowMaterial);

            await _borrowMaterialRepository.DeleteAsync(borrowMaterial!);

            DeletedBorrowMaterialResponse response = _mapper.Map<DeletedBorrowMaterialResponse>(borrowMaterial);
            return response;
        }
    }
}