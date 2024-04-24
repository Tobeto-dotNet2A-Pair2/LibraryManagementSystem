using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Library: Entity<Guid>
{
    public string Name { get; set; }
    public Library() { }

    public Library(string name) {  Name = name; }

    public virtual MemberContact MemberContact { get; set; }
    public virtual ICollection<Branch> Branches { get; set; }

}
