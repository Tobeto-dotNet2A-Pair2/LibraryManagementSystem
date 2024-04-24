using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialGenres.Queries.GetList;

public class GetListMaterialGenreListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }
}