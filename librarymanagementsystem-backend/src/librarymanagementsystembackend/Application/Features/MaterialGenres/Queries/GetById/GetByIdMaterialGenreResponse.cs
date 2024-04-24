using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialGenres.Queries.GetById;

public class GetByIdMaterialGenreResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }
}