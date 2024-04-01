using NArchitecture.Core.Application.Responses;

namespace Application.Features.Publishers.Commands.Create;

public class CreatedPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public string PublisherName { get; set; }
    public string PublicationPlace { get; set; }
}