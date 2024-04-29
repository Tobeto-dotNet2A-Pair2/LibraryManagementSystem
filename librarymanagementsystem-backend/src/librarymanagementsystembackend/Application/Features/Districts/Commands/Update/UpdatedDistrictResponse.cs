using NArchitecture.Core.Application.Responses;

namespace Application.Features.Districts.Commands.Update;

public class UpdatedDistrictResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }
}