using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Notification : Entity<Guid>
{
    public string NotificationType { get; set; }
    public DateTime NotificationDate { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
    public virtual ICollection<MemberNotification> MemberNotifications { get; set; }

}
