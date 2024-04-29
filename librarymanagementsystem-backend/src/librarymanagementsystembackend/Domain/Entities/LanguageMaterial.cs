using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class LanguageMaterial : Entity<Guid>
{
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }

    public virtual Language Language { get; set; }
    public virtual Material Material { get; set; }
}
