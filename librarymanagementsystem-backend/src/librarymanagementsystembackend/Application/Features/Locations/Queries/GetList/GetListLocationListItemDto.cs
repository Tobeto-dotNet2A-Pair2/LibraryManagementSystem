using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Locations.Queries.GetList;

public class GetListLocationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ShelfLineNumber { get; set; }
    public string ShelfFloor { get; set; }
    public string Shelf { get; set; }
    public string Corridor { get; set; }
    public string Floor { get; set; }
    public Guid MaterialCopyId { get; set; }
}