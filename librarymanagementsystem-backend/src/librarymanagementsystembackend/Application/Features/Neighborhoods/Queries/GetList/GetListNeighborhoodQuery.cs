using Application.Features.Neighborhoods.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Neighborhoods.Constants.NeighborhoodsOperationClaims;

namespace Application.Features.Neighborhoods.Queries.GetList;

public class GetListNeighborhoodQuery : IRequest<GetListResponse<GetListNeighborhoodListItemDto>>, ICachableRequest, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListNeighborhoods({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetNeighborhoods";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListNeighborhoodQueryHandler : IRequestHandler<GetListNeighborhoodQuery, GetListResponse<GetListNeighborhoodListItemDto>>
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly IMapper _mapper;

        public GetListNeighborhoodQueryHandler(INeighborhoodRepository neighborhoodRepository, IMapper mapper)
        {
            _neighborhoodRepository = neighborhoodRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNeighborhoodListItemDto>> Handle(GetListNeighborhoodQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Neighborhood> neighborhoods = await _neighborhoodRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListNeighborhoodListItemDto> response = _mapper.Map<GetListResponse<GetListNeighborhoodListItemDto>>(neighborhoods);
            return response;
        }
    }
}