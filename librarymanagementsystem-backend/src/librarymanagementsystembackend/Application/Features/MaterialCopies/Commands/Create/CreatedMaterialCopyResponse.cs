using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialCopies.Commands.Create;

public class CreatedMaterialCopyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
}