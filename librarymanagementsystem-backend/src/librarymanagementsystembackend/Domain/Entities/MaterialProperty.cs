using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialProperty : Entity<Guid>
{
    public string Name { get; set; }
    public MaterialProperty() { }
    public MaterialProperty(string name) { Name = name; }

    public virtual ICollection<MaterialPropertyValue> MaterialPropertyValues { get; set; }
}
