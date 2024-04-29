using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteLists.Commands.Update;

public class UpdatedFavoriteListResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MemberId { get; set; }
}