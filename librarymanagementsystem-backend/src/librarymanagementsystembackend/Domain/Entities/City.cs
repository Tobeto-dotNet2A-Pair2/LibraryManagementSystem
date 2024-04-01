using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class City : Entity<Guid>
{
    public string CityName { get; set; }
    public virtual ICollection<District>? Districts { get; set; } 
}
