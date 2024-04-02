using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Library: Entity<Guid>
{
    public string LibraryName { get; set; }
   
    public virtual MemberContact? MemberContact { get; set; }
    public virtual ICollection<Branch> Branches { get; set; }

}
