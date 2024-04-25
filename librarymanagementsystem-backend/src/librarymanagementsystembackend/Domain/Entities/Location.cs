using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Location : Entity<Guid>
{
    public string? ShelfLineNumber { get; set; }
    public string? ShelfFloor { get; set; }
    public string? Shelf { get; set; }
    public string? Corridor { get; set; }
    public string? Floor { get; set; }
    public string? FullLocationMap { get; set; }

    public Location() { }

    public Location(string? shelfLineNumber, string? shelfFloor, string? shelf, string? corridor, string? floor, string? fullLocationMap)
    {
        ShelfLineNumber = shelfLineNumber;
        ShelfFloor = shelfFloor;
        Shelf = shelf;
        Corridor = corridor;
        Floor = floor;
        FullLocationMap = fullLocationMap;
    }

    public virtual MaterialCopy MaterialCopy { get; set; }


}
