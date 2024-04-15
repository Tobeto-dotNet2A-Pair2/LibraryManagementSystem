using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorMaterials.Commands.Delete;

public class DeletedAuthorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}