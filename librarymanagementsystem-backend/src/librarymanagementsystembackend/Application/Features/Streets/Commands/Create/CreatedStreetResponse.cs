using NArchitecture.Core.Application.Responses;

namespace Application.Features.Streets.Commands.Create;

public class CreatedStreetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid NeighborhoodId { get; set; }
}