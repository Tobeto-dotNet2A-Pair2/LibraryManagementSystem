using NArchitecture.Core.Application.Responses;

namespace Application.Features.PublisherMaterials.Queries.GetById;

public class GetByIdPublisherMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PublisherId { get; set; }
    public Guid MaterialId { get; set; }
}