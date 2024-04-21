using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaterialPropertyValue : Entity<Guid>
{
    public string MaterialPropertyValueName { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }
    public virtual Material Material { get; set; }
    public virtual MaterialType MaterialType { get; set; }
    public virtual MaterialProperty MaterialProperty { get; set; }
}
