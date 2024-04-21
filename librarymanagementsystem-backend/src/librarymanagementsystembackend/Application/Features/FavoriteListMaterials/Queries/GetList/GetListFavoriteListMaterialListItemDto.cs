using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FavoriteListMaterials.Queries.GetList;

public class GetListFavoriteListMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid FavoriteListId { get; set; }
    public Guid MaterialId { get; set; }
}