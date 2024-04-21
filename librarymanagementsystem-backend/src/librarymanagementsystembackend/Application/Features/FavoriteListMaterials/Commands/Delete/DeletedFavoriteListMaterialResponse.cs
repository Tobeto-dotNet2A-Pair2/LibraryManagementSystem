using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteListMaterials.Commands.Delete;

public class DeletedFavoriteListMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}