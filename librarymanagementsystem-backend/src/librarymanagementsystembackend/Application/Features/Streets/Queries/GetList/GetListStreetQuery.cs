using Application.Features.Streets.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Streets.Constants.StreetsOperationClaims;

namespace Application.Features.Streets.Queries.GetList;

public class GetListStreetQuery : IRequest<GetListResponse<GetListStreetListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListStreets({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetStreets";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStreetQueryHandler : IRequestHandler<GetListStreetQuery, GetListResponse<GetListStreetListItemDto>>
    {
        private readonly IStreetRepository _streetRepository;
        private readonly IMapper _mapper;

        public GetListStreetQueryHandler(IStreetRepository streetRepository, IMapper mapper)
        {
            _streetRepository = streetRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStreetListItemDto>> Handle(GetListStreetQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Street> streets = await _streetRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStreetListItemDto> response = _mapper.Map<GetListResponse<GetListStreetListItemDto>>(streets);
            return response;
        }
    }
}