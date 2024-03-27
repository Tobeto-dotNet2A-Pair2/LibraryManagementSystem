using NArchitecture.Core.Application.Responses;

namespace Application.Features.Neighborhoods.Commands.Create;

public class CreatedNeighborhoodResponse : IResponse
{
    public Guid Id { get; set; }
    public string NeighborhoodName { get; set; }
    public Guid DistrictId { get; set; }
}