using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorMaterial : Entity<Guid>
{
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }
 
    public virtual Author Author { get; set; }
    public virtual Material Material { get; set; }
}
