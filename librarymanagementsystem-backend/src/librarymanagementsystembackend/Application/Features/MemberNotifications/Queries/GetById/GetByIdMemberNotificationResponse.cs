using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberNotifications.Queries.GetById;

public class GetByIdMemberNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }
}