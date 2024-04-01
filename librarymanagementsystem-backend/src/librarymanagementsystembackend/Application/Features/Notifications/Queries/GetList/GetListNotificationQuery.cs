using Application.Features.Notifications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Notifications.Constants.NotificationsOperationClaims;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationQuery : IRequest<GetListResponse<GetListNotificationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListNotifications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetNotifications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, GetListResponse<GetListNotificationListItemDto>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetListNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNotificationListItemDto>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Notification> notifications = await _notificationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListNotificationListItemDto> response = _mapper.Map<GetListResponse<GetListNotificationListItemDto>>(notifications);
            return response;
        }
    }
}