using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Neighborhood : Entity<Guid>
{
    public string NeighborhoodName { get; set; }
    public Guid DistrictId { get; set; }
    public virtual District District { get; set; }
    public virtual ICollection<Street> Streets { get; set; }
   
}
