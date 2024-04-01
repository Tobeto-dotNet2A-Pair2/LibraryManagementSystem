using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Publishers.Queries.GetList;

public class GetListPublisherListItemDto : IDto
{
    public Guid Id { get; set; }
    public string PublisherName { get; set; }
    public string PublicationPlace { get; set; }
}