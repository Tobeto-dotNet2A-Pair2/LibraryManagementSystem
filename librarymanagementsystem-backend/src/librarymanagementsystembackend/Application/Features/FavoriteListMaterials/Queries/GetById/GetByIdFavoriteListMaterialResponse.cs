using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteListMaterials.Queries.GetById;

public class GetByIdFavoriteListMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid FavoriteListId { get; set; }
    public Guid MaterialId { get; set; }
}