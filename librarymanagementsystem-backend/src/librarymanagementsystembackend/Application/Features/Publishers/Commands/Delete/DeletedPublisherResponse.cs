using NArchitecture.Core.Application.Responses;

namespace Application.Features.Publishers.Commands.Delete;

public class DeletedPublisherResponse : IResponse
{
    public Guid Id { get; set; }
}