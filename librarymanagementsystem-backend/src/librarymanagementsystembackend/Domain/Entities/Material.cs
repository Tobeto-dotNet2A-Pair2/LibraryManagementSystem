using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Material : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Punishment { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; }


    public virtual ICollection<MaterialCopy>? MaterialCopies { get; set; }
    
}
