using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorMaterials.Queries.GetList;

public class GetListAuthorMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }
}