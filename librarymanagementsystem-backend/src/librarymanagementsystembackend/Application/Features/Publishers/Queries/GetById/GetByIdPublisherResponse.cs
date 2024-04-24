using NArchitecture.Core.Application.Responses;

namespace Application.Features.Publishers.Queries.GetById;

public class GetByIdPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PublicationPlace { get; set; }
}