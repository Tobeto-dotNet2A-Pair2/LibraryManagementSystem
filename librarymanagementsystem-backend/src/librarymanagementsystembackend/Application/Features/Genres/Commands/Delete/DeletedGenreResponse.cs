using NArchitecture.Core.Application.Responses;

namespace Application.Features.Genres.Commands.Delete;

public class DeletedGenreResponse : IResponse
{
    public Guid Id { get; set; }
}