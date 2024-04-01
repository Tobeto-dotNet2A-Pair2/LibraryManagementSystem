using Application.Features.BorrowedMaterials.Constants;
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

namespace Application.Features.BorrowedMaterials.Commands.Delete;

public class DeleteBorrowedMaterialCommand : IRequest<DeletedBorrowedMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BorrowedMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBorrowedMaterials"];

    public class DeleteBorrowedMaterialCommandHandler : IRequestHandler<DeleteBorrowedMaterialCommand, DeletedBorrowedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;

        public DeleteBorrowedMaterialCommandHandler(IMapper mapper, IBorrowedMaterialRepository borrowedMaterialRepository,
                                         BorrowedMaterialBusinessRules borrowedMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
        }

        public async Task<DeletedBorrowedMaterialResponse> Handle(DeleteBorrowedMaterialCommand request, CancellationToken cancellationToken)
        {
            BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _borrowedMaterialBusinessRules.BorrowedMaterialShouldExistWhenSelected(borrowedMaterial);

            await _borrowedMaterialRepository.DeleteAsync(borrowedMaterial!);

            DeletedBorrowedMaterialResponse response = _mapper.Map<DeletedBorrowedMaterialResponse>(borrowedMaterial);
            return response;
        }
    }
}