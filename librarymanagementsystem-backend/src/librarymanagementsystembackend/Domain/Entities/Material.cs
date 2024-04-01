using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Material : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal? PunishmentAmount { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; }

    public virtual ICollection<Language>? Languages { get; set; }
    public virtual ICollection<Author>? Authors { get; set; }
    public virtual ICollection<Publisher>? Publishers { get; set; }
    public virtual ICollection<Translator>? Translators { get; set; }
    public virtual ICollection<MaterialCopy>? MaterialCopies { get; set; }
    public virtual ICollection<FavoriteList>? FavoriteLists { get; set; }
    public virtual ICollection<MaterialPropertyValue>? MaterialPropertyValues { get; set; }
}
