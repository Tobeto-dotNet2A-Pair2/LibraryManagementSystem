using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Language:Entity<Guid>
{
    public string Name { get; set; }

    public Language() { }

    public Language(string name) { Name = name; }
    public virtual ICollection<LanguageMaterial> LanguageMaterials { get; set; }
}
