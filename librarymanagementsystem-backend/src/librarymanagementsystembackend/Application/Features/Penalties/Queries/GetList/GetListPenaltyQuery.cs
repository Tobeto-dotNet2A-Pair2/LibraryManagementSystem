using Application.Features.Penalties.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Penalties.Constants.PenaltiesOperationClaims;

namespace Application.Features.Penalties.Queries.GetList;

public class GetListPenaltyQuery : IRequest<GetListResponse<GetListPenaltyListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPenalties({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPenalties";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPenaltyQueryHandler : IRequestHandler<GetListPenaltyQuery, GetListResponse<GetListPenaltyListItemDto>>
    {
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly IMapper _mapper;

        public GetListPenaltyQueryHandler(IPenaltyRepository penaltyRepository, IMapper mapper)
        {
            _penaltyRepository = penaltyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPenaltyListItemDto>> Handle(GetListPenaltyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Penalty> penalties = await _penaltyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPenaltyListItemDto> response = _mapper.Map<GetListResponse<GetListPenaltyListItemDto>>(penalties);
            return response;
        }
    }
}