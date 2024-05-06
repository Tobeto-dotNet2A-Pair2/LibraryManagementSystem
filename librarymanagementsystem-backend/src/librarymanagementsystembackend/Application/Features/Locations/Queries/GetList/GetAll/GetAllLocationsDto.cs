namespace Application.Features.Locations.Queries.GetList.GetAll;
public class GetAllLocationsDto
{
    public Guid Id { get; set; }
    public string? ShelfLineNumber { get; set; }
    public string? ShelfFloor { get; set; }
    public string? Shelf { get; set; }
    public string? Corridor { get; set; }
    public string? Floor { get; set; }
    public string? FullLocationMap { get; set; }
}

