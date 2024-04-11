using NArchitecture.Core.Application.Responses;

namespace Application.Features.PublisherMaterials.Commands.Update;

public class UpdatedPublisherMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PublisherId { get; set; }
    public Guid MaterialId { get; set; }
}