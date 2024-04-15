using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteListMaterials.Commands.Create;

public class CreatedFavoriteListMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid FavoriteListId { get; set; }
    public Guid MaterialId { get; set; }
}