using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialGenres.Commands.Delete;

public class DeletedMaterialGenreResponse : IResponse
{
    public Guid Id { get; set; }
}