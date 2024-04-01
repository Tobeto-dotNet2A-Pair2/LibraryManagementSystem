using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Commands.Delete;

public class DeletedLocationResponse : IResponse
{
    public Guid Id { get; set; }
}