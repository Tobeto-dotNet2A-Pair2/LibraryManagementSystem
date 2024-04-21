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

namespace Application.Features.FavoriteListMaterials.Commands.Create;

public class CreateFavoriteListMaterialCommand : IRequest<CreatedFavoriteListMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid FavoriteListId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, FavoriteListMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFavoriteListMaterials"];

    public class CreateFavoriteListMaterialCommandHandler : IRequestHandler<CreateFavoriteListMaterialCommand, CreatedFavoriteListMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
        private readonly FavoriteListMaterialBusinessRules _favoriteListMaterialBusinessRules;

        public CreateFavoriteListMaterialCommandHandler(IMapper mapper, IFavoriteListMaterialRepository favoriteListMaterialRepository,
                                         FavoriteListMaterialBusinessRules favoriteListMaterialBusinessRules)
        {
            _mapper = mapper;
            _favoriteListMaterialRepository = favoriteListMaterialRepository;
            _favoriteListMaterialBusinessRules = favoriteListMaterialBusinessRules;
        }

        public async Task<CreatedFavoriteListMaterialResponse> Handle(CreateFavoriteListMaterialCommand request, CancellationToken cancellationToken)
        {
            FavoriteListMaterial favoriteListMaterial = _mapper.Map<FavoriteListMaterial>(request);

            await _favoriteListMaterialRepository.AddAsync(favoriteListMaterial);

            CreatedFavoriteListMaterialResponse response = _mapper.Map<CreatedFavoriteListMaterialResponse>(favoriteListMaterial);
            return response;
        }
    }
}