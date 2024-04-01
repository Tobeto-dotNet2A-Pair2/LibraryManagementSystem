using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Location : Entity<Guid>
{
    public string ShelfLineNumber { get; set; }
    public string ShelfFloor { get; set; }
    public string Shelf { get; set; }
    public string Corridor { get; set; }
    public string Floor { get; set; }

    public virtual 
}
