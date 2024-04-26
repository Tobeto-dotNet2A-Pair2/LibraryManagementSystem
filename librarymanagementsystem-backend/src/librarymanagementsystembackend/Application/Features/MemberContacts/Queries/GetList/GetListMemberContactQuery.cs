using Application.Features.MemberContacts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MemberContacts.Constants.MemberContactsOperationClaims;

namespace Application.Features.MemberContacts.Queries.GetList;

public class GetListMemberContactQuery : IRequest<GetListResponse<GetListMemberContactListItemDto>>, ICachableRequest // ISecuredRequest,
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMemberContacts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMemberContacts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMemberContactQueryHandler : IRequestHandler<GetListMemberContactQuery, GetListResponse<GetListMemberContactListItemDto>>
    {
        private readonly IMemberContactRepository _memberContactRepository;
        private readonly IMapper _mapper;

        public GetListMemberContactQueryHandler(IMemberContactRepository memberContactRepository, IMapper mapper)
        {
            _memberContactRepository = memberContactRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMemberContactListItemDto>> Handle(GetListMemberContactQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MemberContact> memberContacts = await _memberContactRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMemberContactListItemDto> response = _mapper.Map<GetListResponse<GetListMemberContactListItemDto>>(memberContacts);
            return response;
        }
    }
}