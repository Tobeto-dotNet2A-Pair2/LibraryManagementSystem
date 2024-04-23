using NArchitecture.Core.Application.Responses;

namespace Application.Features.Genres.Commands.Create;

public class CreatedGenreResponse : IResponse
{
    public Guid Id { get; set; }
    public string GenreName { get; set; }
}