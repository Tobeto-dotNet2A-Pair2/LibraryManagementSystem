using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Genres.Queries.GetList;

public class GetListGenreListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}