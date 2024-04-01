using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialProperties.Commands.Delete;

public class DeletedMaterialPropertyResponse : IResponse
{
    public Guid Id { get; set; }
}