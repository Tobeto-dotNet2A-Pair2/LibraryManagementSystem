using Application.Features.FavoriteListMaterials.Constants;
using Application.Features.FavoriteListMaterials.Constants;
using Application.Features.FavoriteListMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FavoriteListMaterials.Constants.FavoriteListMaterialsOperationClaims;

namespace Application.Features.FavoriteListMaterials.Commands.Delete;

public class DeleteFavoriteListMaterialCommand : IRequest<DeletedFavoriteListMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, FavoriteListMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFavoriteListMaterials"];

    public class DeleteFavoriteListMaterialCommandHandler : IRequestHandler<DeleteFavoriteListMaterialCommand, DeletedFavoriteListMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
        private readonly FavoriteListMaterialBusinessRules _favoriteListMaterialBusinessRules;

        public DeleteFavoriteListMaterialCommandHandler(IMapper mapper, IFavoriteListMaterialRepository favoriteListMaterialRepository,
                                         FavoriteListMaterialBusinessRules favoriteListMaterialBusinessRules)
        {
            _mapper = mapper;
            _favoriteListMaterialRepository = favoriteListMaterialRepository;
            _favoriteListMaterialBusinessRules = favoriteListMaterialBusinessRules;
        }

        public async Task<DeletedFavoriteListMaterialResponse> Handle(DeleteFavoriteListMaterialCommand request, CancellationToken cancellationToken)
        {
            FavoriteListMaterial? favoriteListMaterial = await _favoriteListMaterialRepository.GetAsync(predicate: flm => flm.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteListMaterialBusinessRules.FavoriteListMaterialShouldExistWhenSelected(favoriteListMaterial);

            await _favoriteListMaterialRepository.DeleteAsync(favoriteListMaterial!);

            DeletedFavoriteListMaterialResponse response = _mapper.Map<DeletedFavoriteListMaterialResponse>(favoriteListMaterial);
            return response;
        }
    }
}