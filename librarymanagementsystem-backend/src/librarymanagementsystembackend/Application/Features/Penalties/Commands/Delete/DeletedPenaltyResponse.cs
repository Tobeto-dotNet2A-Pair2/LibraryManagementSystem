using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Commands.Delete;

public class DeletedPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
}