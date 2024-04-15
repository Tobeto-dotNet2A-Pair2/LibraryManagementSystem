using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaterialProperty : Entity<Guid>
{
    public string MaterialPropertyName { get; set; }
    public virtual ICollection<MaterialPropertyValue> MaterialPropertyValues { get; set; }
}
