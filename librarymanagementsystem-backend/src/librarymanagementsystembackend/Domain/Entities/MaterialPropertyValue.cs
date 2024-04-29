using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialPropertyValue : Entity<Guid>
{
    public string Content { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }
    public MaterialPropertyValue() { }

    public MaterialPropertyValue(string content, Guid materialId, Guid materialTypeId, Guid materialPropertyId)
    {
        Content = content;
        MaterialId = materialId;
        MaterialTypeId = materialTypeId;
        MaterialPropertyId = materialPropertyId;
    }

    public virtual Material Material { get; set; }
    public virtual MaterialType MaterialType { get; set; }
    public virtual MaterialProperty MaterialProperty { get; set; }
}
