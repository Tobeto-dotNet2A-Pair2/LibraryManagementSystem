using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MemberAddress : Entity<Guid>
{
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }

    public virtual Member Member { get; set; }
    public virtual Address Address { get; set; }

}
