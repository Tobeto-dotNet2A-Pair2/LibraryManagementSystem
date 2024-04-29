using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FavoriteLists.Queries.GetList;

public class GetListFavoriteListListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MemberId { get; set; }
}