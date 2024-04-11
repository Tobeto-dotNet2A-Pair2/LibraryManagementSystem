using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PublisherMaterials.Queries.GetList;

public class GetListPublisherMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid PublisherId { get; set; }
    public Guid MaterialId { get; set; }
}