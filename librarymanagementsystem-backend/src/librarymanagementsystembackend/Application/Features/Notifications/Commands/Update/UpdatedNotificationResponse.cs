using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Update;

public class UpdatedNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public DateTime SendingDate { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
}