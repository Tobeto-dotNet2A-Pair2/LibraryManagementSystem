using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Queries.GetById;

public class GetByIdLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ShelfLineNumber { get; set; }
    public string? ShelfFloor { get; set; }
    public string? Shelf { get; set; }
    public string? Corridor { get; set; }
    public string? Floor { get; set; }
    public string? FullLocationMap { get; set; }
}