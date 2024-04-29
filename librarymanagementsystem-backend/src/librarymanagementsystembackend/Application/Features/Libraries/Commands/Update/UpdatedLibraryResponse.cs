using NArchitecture.Core.Application.Responses;

namespace Application.Features.Libraries.Commands.Update;

public class UpdatedLibraryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}