using Application.Features.MemberAddresses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MemberAddresses.Constants.MemberAddressesOperationClaims;

namespace Application.Features.MemberAddresses.Queries.GetList;

public class GetListMemberAddressQuery : IRequest<GetListResponse<GetListMemberAddressListItemDto>>, ICachableRequest, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMemberAddresses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMemberAddresses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMemberAddressQueryHandler : IRequestHandler<GetListMemberAddressQuery, GetListResponse<GetListMemberAddressListItemDto>>
    {
        private readonly IMemberAddressRepository _memberAddressRepository;
        private readonly IMapper _mapper;

        public GetListMemberAddressQueryHandler(IMemberAddressRepository memberAddressRepository, IMapper mapper)
        {
            _memberAddressRepository = memberAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMemberAddressListItemDto>> Handle(GetListMemberAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MemberAddress> memberAddresses = await _memberAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMemberAddressListItemDto> response = _mapper.Map<GetListResponse<GetListMemberAddressListItemDto>>(memberAddresses);
            return response;
        }
    }
}