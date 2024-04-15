using NArchitecture.Core.Application.Responses;

namespace Application.Features.Genres.Commands.Update;

public class UpdatedGenreResponse : IResponse
{
    public Guid Id { get; set; }
    public string GenreName { get; set; }
}