using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteLists.Commands.Delete;

public class DeletedFavoriteListResponse : IResponse
{
    public Guid Id { get; set; }
}