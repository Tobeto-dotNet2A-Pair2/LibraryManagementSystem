using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Commands.Update;

public class UpdatedLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string ShelfLineNumber { get; set; }
    public string ShelfFloor { get; set; }
    public string Shelf { get; set; }
    public string Corridor { get; set; }
    public string Floor { get; set; }
}