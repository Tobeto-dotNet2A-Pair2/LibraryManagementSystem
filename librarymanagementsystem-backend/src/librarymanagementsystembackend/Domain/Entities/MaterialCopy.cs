using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MaterialCopy : Entity<Guid>
{
    // todo?: DateTime PublicationArrivalDate 
    public string Status { get; set; }
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid LocationId { get; set; }

    public virtual Material? Material { get; set; }
    public virtual Branch? Branch { get; set; }
    public virtual Location? Location { get; set; }

    
}
