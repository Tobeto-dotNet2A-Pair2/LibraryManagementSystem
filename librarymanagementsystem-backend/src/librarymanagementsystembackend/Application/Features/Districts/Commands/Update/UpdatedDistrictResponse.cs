using NArchitecture.Core.Application.Responses;

namespace Application.Features.Districts.Commands.Update;

public class UpdatedDistrictResponse : IResponse
{
    public Guid Id { get; set; }
    public string DistrictName { get; set; }
    public Guid CityId { get; set; }
}