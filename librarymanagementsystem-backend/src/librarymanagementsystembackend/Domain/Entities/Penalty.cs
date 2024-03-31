using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Penalty : Entity<Guid>
{
    public decimal AmountPenalty { get; set; }
    public int DayDelay { get; set; }
    public DateTime FirstDayPunishment { get; set; }
    public decimal TotalPenalty { get; set; }
    public virtual Notification? Notification { get; set; }

}
