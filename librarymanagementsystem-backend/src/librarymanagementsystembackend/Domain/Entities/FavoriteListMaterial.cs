using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class FavoriteListMaterial : Entity<Guid>
{
    public Guid FavoriteListId { get; set; }
    public Guid MaterialId { get; set; }

    public virtual FavoriteList FavoriteList { get; set; }
    public virtual Material Material { get; set; }
}
