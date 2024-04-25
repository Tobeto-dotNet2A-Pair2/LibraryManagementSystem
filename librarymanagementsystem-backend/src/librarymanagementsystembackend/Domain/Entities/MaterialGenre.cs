using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialGenre : Entity<Guid>
{
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }

    public virtual Genre Genre { get; set; }
    public virtual Material Material { get; set; }
}
