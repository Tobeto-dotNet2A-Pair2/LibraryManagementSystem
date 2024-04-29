using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorMaterials.Commands.Update;

public class UpdatedAuthorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }
}