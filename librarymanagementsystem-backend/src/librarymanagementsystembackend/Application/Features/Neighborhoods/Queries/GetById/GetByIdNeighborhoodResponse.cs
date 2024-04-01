using NArchitecture.Core.Application.Responses;

namespace Application.Features.Neighborhoods.Queries.GetById;

public class GetByIdNeighborhoodResponse : IResponse
{
    public Guid Id { get; set; }
    public string NeighborhoodName { get; set; }
    public Guid DistrictId { get; set; }
}