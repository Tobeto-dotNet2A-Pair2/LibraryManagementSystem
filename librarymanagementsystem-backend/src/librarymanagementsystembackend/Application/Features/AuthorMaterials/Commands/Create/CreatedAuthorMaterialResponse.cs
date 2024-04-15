using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorMaterials.Commands.Create;

public class CreatedAuthorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }
}