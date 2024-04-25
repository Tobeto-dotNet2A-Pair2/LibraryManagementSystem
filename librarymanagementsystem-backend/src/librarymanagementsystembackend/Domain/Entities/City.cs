using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class City : Entity<Guid>
{
    public string Name { get; set; }
    public City() { }

    public City(string name) { Name = name; }
    public virtual ICollection<District> Districts { get; set; }
}
