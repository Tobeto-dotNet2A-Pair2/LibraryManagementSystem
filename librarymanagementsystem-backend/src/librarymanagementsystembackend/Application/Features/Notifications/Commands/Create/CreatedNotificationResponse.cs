using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Create;

public class CreatedNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public DateTime SendingDate { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
}