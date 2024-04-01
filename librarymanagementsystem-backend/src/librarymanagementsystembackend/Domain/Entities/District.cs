using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class District : Entity<Guid>
{
    public string DistrictName { get; set; }
    public Guid CityId { get; set; }
    public virtual ICollection<Neighborhood>? Neighborhoods { get; set; }
    public virtual City? City { get; set; }
}
