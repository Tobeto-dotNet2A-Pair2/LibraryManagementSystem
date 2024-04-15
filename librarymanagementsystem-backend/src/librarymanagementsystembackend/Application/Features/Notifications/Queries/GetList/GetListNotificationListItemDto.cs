using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string NotificationType { get; set; }
    public DateTime NotificationDate { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
}