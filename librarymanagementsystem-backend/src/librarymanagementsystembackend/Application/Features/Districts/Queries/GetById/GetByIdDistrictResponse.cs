using NArchitecture.Core.Application.Responses;

namespace Application.Features.Districts.Queries.GetById;

public class GetByIdDistrictResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }
}