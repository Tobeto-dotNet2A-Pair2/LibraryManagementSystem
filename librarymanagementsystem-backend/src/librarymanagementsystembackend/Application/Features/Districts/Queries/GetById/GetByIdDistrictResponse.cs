using NArchitecture.Core.Application.Responses;

namespace Application.Features.Districts.Queries.GetById;

public class GetByIdDistrictResponse : IResponse
{
    public Guid Id { get; set; }
    public string DistrictName { get; set; }
    public Guid CityId { get; set; }
}