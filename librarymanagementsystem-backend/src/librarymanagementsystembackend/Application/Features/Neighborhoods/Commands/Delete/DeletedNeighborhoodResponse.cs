using NArchitecture.Core.Application.Responses;

namespace Application.Features.Neighborhoods.Commands.Delete;

public class DeletedNeighborhoodResponse : IResponse
{
    public Guid Id { get; set; }
}