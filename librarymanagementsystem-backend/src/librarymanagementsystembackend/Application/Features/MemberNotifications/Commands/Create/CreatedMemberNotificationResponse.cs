using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberNotifications.Commands.Create;

public class CreatedMemberNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }
}