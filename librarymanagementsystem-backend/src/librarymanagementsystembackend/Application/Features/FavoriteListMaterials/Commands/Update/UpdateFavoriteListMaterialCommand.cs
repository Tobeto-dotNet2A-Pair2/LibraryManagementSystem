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

namespace Application.Features.FavoriteListMaterials.Commands.Update;

public class UpdateFavoriteListMaterialCommand : IRequest<UpdatedFavoriteListMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid FavoriteListId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, FavoriteListMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFavoriteListMaterials"];

    public class UpdateFavoriteListMaterialCommandHandler : IRequestHandler<UpdateFavoriteListMaterialCommand, UpdatedFavoriteListMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
        private readonly FavoriteListMaterialBusinessRules _favoriteListMaterialBusinessRules;

        public UpdateFavoriteListMaterialCommandHandler(IMapper mapper, IFavoriteListMaterialRepository favoriteListMaterialRepository,
                                         FavoriteListMaterialBusinessRules favoriteListMaterialBusinessRules)
        {
            _mapper = mapper;
            _favoriteListMaterialRepository = favoriteListMaterialRepository;
            _favoriteListMaterialBusinessRules = favoriteListMaterialBusinessRules;
        }

        public async Task<UpdatedFavoriteListMaterialResponse> Handle(UpdateFavoriteListMaterialCommand request, CancellationToken cancellationToken)
        {
            FavoriteListMaterial? favoriteListMaterial = await _favoriteListMaterialRepository.GetAsync(predicate: flm => flm.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteListMaterialBusinessRules.FavoriteListMaterialShouldExistWhenSelected(favoriteListMaterial);
            favoriteListMaterial = _mapper.Map(request, favoriteListMaterial);

            await _favoriteListMaterialRepository.UpdateAsync(favoriteListMaterial!);

            UpdatedFavoriteListMaterialResponse response = _mapper.Map<UpdatedFavoriteListMaterialResponse>(favoriteListMaterial);
            return response;
        }
    }
}