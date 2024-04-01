using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Delete;

public class DeletedNotificationResponse : IResponse
{
    public Guid Id { get; set; }
}