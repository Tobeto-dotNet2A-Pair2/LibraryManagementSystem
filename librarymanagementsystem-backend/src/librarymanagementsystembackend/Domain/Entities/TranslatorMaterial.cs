using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class TranslatorMaterial : Entity<Guid>
{
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }

    public virtual Translator Translator { get; set; }
    public virtual Material Material { get; set; }
}
