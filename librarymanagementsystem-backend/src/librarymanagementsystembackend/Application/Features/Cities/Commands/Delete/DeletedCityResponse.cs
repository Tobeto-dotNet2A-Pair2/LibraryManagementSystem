using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Commands.Delete;

public class DeletedCityResponse : IResponse
{
    public Guid Id { get; set; }
}