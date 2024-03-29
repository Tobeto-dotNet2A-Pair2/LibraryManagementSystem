using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteLists.Commands.Create;

public class CreatedFavoriteListResponse : IResponse
{
    public Guid Id { get; set; }
    public string ListName { get; set; }
    public Guid MemberId { get; set; }
}