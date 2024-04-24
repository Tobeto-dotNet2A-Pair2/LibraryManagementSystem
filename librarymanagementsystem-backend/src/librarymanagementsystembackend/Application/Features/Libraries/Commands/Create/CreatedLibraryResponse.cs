using NArchitecture.Core.Application.Responses;

namespace Application.Features.Libraries.Commands.Create;

public class CreatedLibraryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}