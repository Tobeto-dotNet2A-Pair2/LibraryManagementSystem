using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberNotifications.Commands.Update;

public class UpdatedMemberNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }
}