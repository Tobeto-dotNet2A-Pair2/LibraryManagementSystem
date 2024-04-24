using NArchitecture.Core.Application.Responses;

namespace Application.Features.Neighborhoods.Commands.Update;

public class UpdatedNeighborhoodResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DistrictId { get; set; }
}