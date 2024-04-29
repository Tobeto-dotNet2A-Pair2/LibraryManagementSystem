using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Address : Entity<Guid>
{
    public Guid StreetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Address() { }

    public Address(Guid streetId, string name, string description)
    {
        StreetId = streetId;
        Name = name;
        Description = description;
    }

    public virtual Street Street { get; set; }
    public virtual Branch Branch { get; set; } 
    public virtual ICollection<MemberAddress> MemberAddresses { get; set; }

   

}
