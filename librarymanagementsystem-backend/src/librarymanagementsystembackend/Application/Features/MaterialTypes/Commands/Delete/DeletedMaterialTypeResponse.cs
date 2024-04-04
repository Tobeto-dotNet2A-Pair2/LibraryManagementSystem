using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Commands.Delete;

public class DeletedMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
}