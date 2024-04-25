using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Penalty : Entity<Guid>
{
    public decimal TotalMaterialDebt { get; set; }
    public int DayDelay { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Penalty() { }

    public Penalty(decimal totalMaterialDebt, int dayDelay, Guid borrowedMaterialId)
    {
        TotalMaterialDebt = totalMaterialDebt;
        DayDelay = dayDelay;
        BorrowedMaterialId = borrowedMaterialId;
    }

    public virtual BorrowedMaterial BorrowedMaterial { get; set; }

}
