using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class FavoriteList : Entity<Guid>
{
    public string Name { get; set; }
    public Guid MemberId { get; set; }
    public FavoriteList() { }

    public FavoriteList(string name, Guid memberId)
    {
        Name = name;
        MemberId = memberId;
    }

    public virtual Member Member { get; set; }
    public virtual ICollection<FavoriteListMaterial> FavoriteListMaterials { get; set; }
}
