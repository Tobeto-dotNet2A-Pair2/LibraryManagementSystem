using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialGenres.Commands.Update;

public class UpdatedMaterialGenreResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }
}