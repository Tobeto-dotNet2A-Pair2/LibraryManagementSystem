using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialGenres.Commands.Create;

public class CreatedMaterialGenreResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }
}