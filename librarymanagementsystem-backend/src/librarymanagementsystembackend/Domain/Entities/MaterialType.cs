using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaterialType : Entity<Guid>
{
    public string MaterialTypeName { get; set; }
    public string MaterialTypeCategory { get; set; }
    public virtual ICollection<MaterialPropertyValue> MaterialPropertyValues { get; set; }
}
