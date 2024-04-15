using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorMaterials.Queries.GetById;

public class GetByIdAuthorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }
}