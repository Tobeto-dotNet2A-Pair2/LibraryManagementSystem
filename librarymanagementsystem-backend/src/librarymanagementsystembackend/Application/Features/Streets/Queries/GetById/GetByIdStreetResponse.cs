using NArchitecture.Core.Application.Responses;

namespace Application.Features.Streets.Queries.GetById;

public class GetByIdStreetResponse : IResponse
{
    public Guid Id { get; set; }
    public string StreetName { get; set; }
    public Guid NeighborhoodId { get; set; }
}