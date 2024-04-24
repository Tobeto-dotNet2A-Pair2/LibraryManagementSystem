using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class PaymentMethod : Entity<Guid>
{
    public string Name { get; set; }
    public Guid BranchId { get; set; }

    public PaymentMethod() { }

    public PaymentMethod(string name, Guid branchId)
    {
        Name = name;
        BranchId = branchId;
    }

    public virtual Branch Branch { get; set; }

}
