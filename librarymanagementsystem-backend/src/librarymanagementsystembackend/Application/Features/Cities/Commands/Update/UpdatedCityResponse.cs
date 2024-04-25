using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Commands.Update;

public class UpdatedCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}