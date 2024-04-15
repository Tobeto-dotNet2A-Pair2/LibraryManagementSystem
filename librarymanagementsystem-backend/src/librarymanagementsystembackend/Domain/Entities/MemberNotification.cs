﻿using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MemberNotification : Entity<Guid>
{
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }

    public virtual Member Member { get; set; }
    public virtual Notification Notification { get; set; }
}
