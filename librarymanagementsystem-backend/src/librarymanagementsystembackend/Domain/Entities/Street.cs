using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Street : Entity<Guid>
{
    public string StreetName { get; set; }

    public Guid NeighborhoodId { get; set; }

    public virtual ICollection <Address> Addresses { get; set; } 
    public virtual Neighborhood Neighborhood { get; set; }
}
