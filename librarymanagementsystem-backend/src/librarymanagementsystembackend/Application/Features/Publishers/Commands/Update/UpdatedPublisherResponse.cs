using NArchitecture.Core.Application.Responses;

namespace Application.Features.Publishers.Commands.Update;

public class UpdatedPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public string PublisherName { get; set; }
    public string PublicationPlace { get; set; }
}