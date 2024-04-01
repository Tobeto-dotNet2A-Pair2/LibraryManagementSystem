using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Commands.Create;

public class CreatedCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string CityName { get; set; }
}