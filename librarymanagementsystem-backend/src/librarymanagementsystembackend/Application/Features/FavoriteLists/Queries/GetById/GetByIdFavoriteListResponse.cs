using NArchitecture.Core.Application.Responses;

namespace Application.Features.FavoriteLists.Queries.GetById;

public class GetByIdFavoriteListResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MemberId { get; set; }
}