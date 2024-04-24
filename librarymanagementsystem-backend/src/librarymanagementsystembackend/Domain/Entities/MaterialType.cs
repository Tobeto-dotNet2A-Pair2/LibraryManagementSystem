using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialType : Entity<Guid>
{
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }
    public MaterialType() { }

    public MaterialType(string name, MaterialFormat materialFormat)
    {
        Name = name;
        MaterialFormat = materialFormat;
    }

    public virtual ICollection<MaterialPropertyValue> MaterialPropertyValues { get; set; }
}
