using NArchitecture.Core.Application.Responses;

namespace Application.Features.Libraries.Queries.GetById;

public class GetByIdLibraryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}