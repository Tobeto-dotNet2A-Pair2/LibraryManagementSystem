using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class District : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CityId { get; set; }

    public District() { }

    public District(string name, Guid cityId)
    {
        Name = name;
        CityId = cityId;
    }

    public virtual City City { get; set; }
    public virtual ICollection<Neighborhood> Neighborhoods { get; set; }

}
