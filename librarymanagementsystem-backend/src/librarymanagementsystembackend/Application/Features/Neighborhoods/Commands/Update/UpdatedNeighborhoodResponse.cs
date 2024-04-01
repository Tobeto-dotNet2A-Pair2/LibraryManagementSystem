using NArchitecture.Core.Application.Responses;

namespace Application.Features.Neighborhoods.Commands.Update;

public class UpdatedNeighborhoodResponse : IResponse
{
    public Guid Id { get; set; }
    public string NeighborhoodName { get; set; }
    public Guid DistrictId { get; set; }
}