using Application.Features.FavoriteListMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.FavoriteListMaterials.Constants.FavoriteListMaterialsOperationClaims;

namespace Application.Features.FavoriteListMaterials.Queries.GetList;

public class GetListFavoriteListMaterialQuery : IRequest<GetListResponse<GetListFavoriteListMaterialListItemDto>>, ICachableRequest,ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListFavoriteListMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetFavoriteListMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListFavoriteListMaterialQueryHandler : IRequestHandler<GetListFavoriteListMaterialQuery, GetListResponse<GetListFavoriteListMaterialListItemDto>>
    {
        private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
        private readonly IMapper _mapper;

        public GetListFavoriteListMaterialQueryHandler(IFavoriteListMaterialRepository favoriteListMaterialRepository, IMapper mapper)
        {
            _favoriteListMaterialRepository = favoriteListMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFavoriteListMaterialListItemDto>> Handle(GetListFavoriteListMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FavoriteListMaterial> favoriteListMaterials = await _favoriteListMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFavoriteListMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListFavoriteListMaterialListItemDto>>(favoriteListMaterials);
            return response;
        }
    }
}