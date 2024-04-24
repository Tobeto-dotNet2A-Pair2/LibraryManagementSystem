using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class BorrowedMaterial : Entity<Guid>
{
    public DateTime BorrowedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool IsReturned { get; set; } = false;
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }

    public BorrowedMaterial() { }
    public BorrowedMaterial(DateTime borrowedDate, DateTime returnDate, bool isReturned, Guid memberId, Guid materialCopyId)
    {
        BorrowedDate = borrowedDate;
        ReturnDate = returnDate;
        IsReturned = isReturned;
        MemberId = memberId;
        MaterialCopyId = materialCopyId;
    }
    public virtual Member Member { get; set; }
    public virtual Penalty Penalty { get; set; }
    public virtual MaterialCopy MaterialCopy { get; set; }

}
