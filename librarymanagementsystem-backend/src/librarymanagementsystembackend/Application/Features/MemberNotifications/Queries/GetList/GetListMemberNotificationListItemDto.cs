using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MemberNotifications.Queries.GetList;

public class GetListMemberNotificationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }
}