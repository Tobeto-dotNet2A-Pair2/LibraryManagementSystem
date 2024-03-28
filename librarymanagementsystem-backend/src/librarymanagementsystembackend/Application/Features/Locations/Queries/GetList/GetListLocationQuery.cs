using Application.Features.Locations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Locations.Constants.LocationsOperationClaims;

namespace Application.Features.Locations.Queries.GetList;

public class GetListLocationQuery : IRequest<GetListResponse<GetListLocationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListLocations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetLocations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLocationQueryHandler : IRequestHandler<GetListLocationQuery, GetListResponse<GetListLocationListItemDto>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetListLocationQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLocationListItemDto>> Handle(GetListLocationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Location> locations = await _locationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLocationListItemDto> response = _mapper.Map<GetListResponse<GetListLocationListItemDto>>(locations);
            return response;
        }
    }
}