using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialCopies.Commands.Delete;

public class DeletedMaterialCopyResponse : IResponse
{
    public Guid Id { get; set; }
}