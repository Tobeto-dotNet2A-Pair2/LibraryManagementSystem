using Application.Features.FavoriteListMaterials.Constants;
using Application.Features.FavoriteListMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FavoriteListMaterials.Constants.FavoriteListMaterialsOperationClaims;

namespace Application.Features.FavoriteListMaterials.Queries.GetById;

public class GetByIdFavoriteListMaterialQuery : IRequest<GetByIdFavoriteListMaterialResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFavoriteListMaterialQueryHandler : IRequestHandler<GetByIdFavoriteListMaterialQuery, GetByIdFavoriteListMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
        private readonly FavoriteListMaterialBusinessRules _favoriteListMaterialBusinessRules;

        public GetByIdFavoriteListMaterialQueryHandler(IMapper mapper, IFavoriteListMaterialRepository favoriteListMaterialRepository, FavoriteListMaterialBusinessRules favoriteListMaterialBusinessRules)
        {
            _mapper = mapper;
            _favoriteListMaterialRepository = favoriteListMaterialRepository;
            _favoriteListMaterialBusinessRules = favoriteListMaterialBusinessRules;
        }

        public async Task<GetByIdFavoriteListMaterialResponse> Handle(GetByIdFavoriteListMaterialQuery request, CancellationToken cancellationToken)
        {
            FavoriteListMaterial? favoriteListMaterial = await _favoriteListMaterialRepository.GetAsync(predicate: flm => flm.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteListMaterialBusinessRules.FavoriteListMaterialShouldExistWhenSelected(favoriteListMaterial);

            GetByIdFavoriteListMaterialResponse response = _mapper.Map<GetByIdFavoriteListMaterialResponse>(favoriteListMaterial);
            return response;
        }
    }
}