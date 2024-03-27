using NArchitecture.Core.Application.Responses;

namespace Application.Features.Libraries.Commands.Delete;

public class DeletedLibraryResponse : IResponse
{
    public Guid Id { get; set; }
}