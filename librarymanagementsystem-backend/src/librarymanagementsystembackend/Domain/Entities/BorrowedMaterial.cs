using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class BorrowedMaterial : Entity<Guid>
{
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool isReturned { get; set; } = false;
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }
    public virtual Member Member { get; set; }
    public virtual Penalty Penalty { get; set; }
    public virtual MaterialCopy MaterialCopy { get; set; }

}
