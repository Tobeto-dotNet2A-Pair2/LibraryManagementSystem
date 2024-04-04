using NArchitecture.Core.Application.Responses;

namespace Application.Features.Streets.Commands.Delete;

public class DeletedStreetResponse : IResponse
{
    public Guid Id { get; set; }
}