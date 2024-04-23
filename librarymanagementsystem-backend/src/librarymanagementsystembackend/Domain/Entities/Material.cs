using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Material : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal? PunishmentAmount { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; } = default;

    public virtual ICollection<MaterialCopy> MaterialCopies { get; set; }
    public virtual ICollection<FavoriteListMaterial> FavoriteListMaterials { get; set; }

    public virtual ICollection<TranslatorMaterial> TranslatorMaterials { get; set; }
    public virtual ICollection<LanguageMaterial> LanguageMaterials { get; set; }
    public virtual ICollection<PublisherMaterial> PublisherMaterials { get; set; }
    public virtual ICollection<AuthorMaterial> AuthorMaterials { get; set; }
    public virtual ICollection<MaterialPropertyValue> MaterialPropertyValues { get; set; }

    public virtual ICollection<MaterialGenre> MaterialGenres { get; set; }
}
