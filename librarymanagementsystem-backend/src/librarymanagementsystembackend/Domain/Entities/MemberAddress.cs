using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MemberAddress : Entity<Guid>
{
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }

    public virtual Member Member { get; set; }
    public virtual Address Address { get; set; }

}
