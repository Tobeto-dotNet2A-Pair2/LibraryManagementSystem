using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Translator : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Translator() { }

    public Translator(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual ICollection<TranslatorMaterial> TranslatorMaterials { get; set; }

}
