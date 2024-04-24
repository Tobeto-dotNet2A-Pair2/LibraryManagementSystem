using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Notification : Entity<Guid>
{
    public string Type { get; set; }
    public DateTime SendingDate { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }

    public Notification() { }

    public Notification(string type, DateTime sendingDate, string message, string status)
    {
        Type = type;
        SendingDate = sendingDate;
        Message = message;
        Status = status;
    }

    public virtual ICollection<MemberNotification> MemberNotifications { get; set; }

}
