using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberNotifications.Commands.Delete;

public class DeletedMemberNotificationResponse : IResponse
{
    public Guid Id { get; set; }
}