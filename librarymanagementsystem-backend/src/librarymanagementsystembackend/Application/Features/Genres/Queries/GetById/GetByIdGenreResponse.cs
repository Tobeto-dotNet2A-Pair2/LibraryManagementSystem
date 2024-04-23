using NArchitecture.Core.Application.Responses;

namespace Application.Features.Genres.Queries.GetById;

public class GetByIdGenreResponse : IResponse
{
    public Guid Id { get; set; }
    public string GenreName { get; set; }
}