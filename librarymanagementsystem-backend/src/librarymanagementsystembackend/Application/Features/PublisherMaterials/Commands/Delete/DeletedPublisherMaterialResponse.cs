using NArchitecture.Core.Application.Responses;

namespace Application.Features.PublisherMaterials.Commands.Delete;

public class DeletedPublisherMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}