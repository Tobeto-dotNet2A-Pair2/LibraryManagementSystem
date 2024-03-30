using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BorrowMaterial : Entity<Guid>
{
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid MemberId { get; set; }
    public virtual Member? Member { get; set; }
    public virtual Penalty? Penalty { get; set; }
    public virtual MaterialCopy? MaterialCopy { get; set; }

}
