using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SocialMediaAccounts.Constants.SocialMediaAccountsOperationClaims;

namespace Application.Features.SocialMediaAccounts.Queries.GetList;

public class GetListSocialMediaAccountQuery : IRequest<GetListResponse<GetListSocialMediaAccountListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSocialMediaAccounts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSocialMediaAccounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSocialMediaAccountQueryHandler : IRequestHandler<GetListSocialMediaAccountQuery, GetListResponse<GetListSocialMediaAccountListItemDto>>
    {
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly IMapper _mapper;

        public GetListSocialMediaAccountQueryHandler(ISocialMediaAccountRepository socialMediaAccountRepository, IMapper mapper)
        {
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSocialMediaAccountListItemDto>> Handle(GetListSocialMediaAccountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SocialMediaAccount> socialMediaAccounts = await _socialMediaAccountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSocialMediaAccountListItemDto> response = _mapper.Map<GetListResponse<GetListSocialMediaAccountListItemDto>>(socialMediaAccounts);
            return response;
        }
    }
}