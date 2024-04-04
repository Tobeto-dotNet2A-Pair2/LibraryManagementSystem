using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialCopy : Entity<Guid>
{
    // todo?: DateTime PublicationArrivalDate 
    public DateTime DateReceipt { get; set; }
    public string Status { get; set; }

    public bool isReserved { get; set; } = false;
    public bool isReservable { get; set; } 
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid LocationId { get; set; }

    public virtual Material Material { get; set; }
    public virtual Branch Branch { get; set; }
    public virtual Location Location { get; set; }
    public virtual BorrowedMaterial BorrowedMaterial { get; set; }

    
}
