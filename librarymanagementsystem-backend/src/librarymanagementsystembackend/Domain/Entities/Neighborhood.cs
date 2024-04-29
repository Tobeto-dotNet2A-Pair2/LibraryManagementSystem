using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Neighborhood : Entity<Guid>
{
    public string Name { get; set; }
    public Guid DistrictId { get; set; }

    public Neighborhood() { }

    public Neighborhood(string name, Guid districtId)
    {
        Name = name;
        DistrictId = districtId;
    }

    public virtual District District { get; set; }
    public virtual ICollection<Street> Streets { get; set; }
   
}
