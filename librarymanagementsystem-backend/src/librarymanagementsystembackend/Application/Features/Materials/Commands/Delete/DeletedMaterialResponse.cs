using NArchitecture.Core.Application.Responses;

namespace Application.Features.Materials.Commands.Delete;

public class DeletedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}