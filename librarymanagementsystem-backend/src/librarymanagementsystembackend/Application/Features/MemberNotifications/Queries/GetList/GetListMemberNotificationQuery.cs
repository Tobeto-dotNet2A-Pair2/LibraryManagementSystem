using Application.Features.MemberNotifications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MemberNotifications.Constants.MemberNotificationsOperationClaims;

namespace Application.Features.MemberNotifications.Queries.GetList;

public class GetListMemberNotificationQuery : IRequest<GetListResponse<GetListMemberNotificationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMemberNotifications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMemberNotifications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMemberNotificationQueryHandler : IRequestHandler<GetListMemberNotificationQuery, GetListResponse<GetListMemberNotificationListItemDto>>
    {
        private readonly IMemberNotificationRepository _memberNotificationRepository;
        private readonly IMapper _mapper;

        public GetListMemberNotificationQueryHandler(IMemberNotificationRepository memberNotificationRepository, IMapper mapper)
        {
            _memberNotificationRepository = memberNotificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMemberNotificationListItemDto>> Handle(GetListMemberNotificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MemberNotification> memberNotifications = await _memberNotificationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMemberNotificationListItemDto> response = _mapper.Map<GetListResponse<GetListMemberNotificationListItemDto>>(memberNotifications);
            return response;
        }
    }
}