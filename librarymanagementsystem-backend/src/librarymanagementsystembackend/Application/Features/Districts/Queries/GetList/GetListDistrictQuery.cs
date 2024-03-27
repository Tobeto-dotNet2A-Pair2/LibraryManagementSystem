using Application.Features.Districts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Districts.Constants.DistrictsOperationClaims;

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictQuery : IRequest<GetListResponse<GetListDistrictListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDistricts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDistricts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDistrictQueryHandler : IRequestHandler<GetListDistrictQuery, GetListResponse<GetListDistrictListItemDto>>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetListDistrictQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDistrictListItemDto>> Handle(GetListDistrictQuery request, CancellationToken cancellationToken)
        {
            IPaginate<District> districts = await _districtRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDistrictListItemDto> response = _mapper.Map<GetListResponse<GetListDistrictListItemDto>>(districts);
            return response;
        }
    }
}