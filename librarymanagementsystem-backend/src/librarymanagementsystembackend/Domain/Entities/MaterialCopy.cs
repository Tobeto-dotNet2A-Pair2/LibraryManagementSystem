using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialCopy : Entity<Guid>
{
    public DateTime DateReceipt { get; set; }
    public string Status { get; set; }
    public bool IsReserved { get; set; } = false;
    public bool IsReservable { get; set; } 
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid LocationId { get; set; }

    public MaterialCopy()
    {
        
    }

    public MaterialCopy(DateTime dateReceipt, string status, bool ısReserved, bool ısReservable, Guid materialId, Guid branchId, Guid locationId)
    {
        DateReceipt = dateReceipt;
        Status = status;
        IsReserved = ısReserved;
        IsReservable = ısReservable;
        MaterialId = materialId;
        BranchId = branchId;
        LocationId = locationId;
    }

    public virtual BorrowedMaterial BorrowedMaterial { get; set; }
    public virtual Material Material { get; set; }
    public virtual Branch Branch { get; set; }
    public virtual Location Location { get; set; }



}
