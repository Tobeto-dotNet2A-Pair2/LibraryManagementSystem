using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Street : Entity<Guid>
{
    public string Name { get; set; }
    public Guid NeighborhoodId { get; set; }
    public Street() { }

    public Street(string name, Guid neighborhoodId)
    {
        Name = name;
        NeighborhoodId = neighborhoodId;
    }

    public virtual Neighborhood Neighborhood { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
   
}
