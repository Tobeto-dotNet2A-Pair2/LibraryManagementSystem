using Application.Features.FavoriteLists.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.FavoriteLists.Constants.FavoriteListsOperationClaims;

namespace Application.Features.FavoriteLists.Queries.GetList;

public class GetListFavoriteListQuery : IRequest<GetListResponse<GetListFavoriteListListItemDto>>, ICachableRequest, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListFavoriteLists({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetFavoriteLists";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListFavoriteListQueryHandler : IRequestHandler<GetListFavoriteListQuery, GetListResponse<GetListFavoriteListListItemDto>>
    {
        private readonly IFavoriteListRepository _favoriteListRepository;
        private readonly IMapper _mapper;

        public GetListFavoriteListQueryHandler(IFavoriteListRepository favoriteListRepository, IMapper mapper)
        {
            _favoriteListRepository = favoriteListRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFavoriteListListItemDto>> Handle(GetListFavoriteListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FavoriteList> favoriteLists = await _favoriteListRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFavoriteListListItemDto> response = _mapper.Map<GetListResponse<GetListFavoriteListListItemDto>>(favoriteLists);
            return response;
        }
    }
}