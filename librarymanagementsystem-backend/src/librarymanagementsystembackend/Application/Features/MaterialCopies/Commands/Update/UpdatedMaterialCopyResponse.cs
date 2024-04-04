using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialCopies.Commands.Update;

public class UpdatedMaterialCopyResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime DateReceipt { get; set; }
    public string Status { get; set; }
    public bool IsReserved { get; set; }
    public bool IsReservable { get; set; }
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid LocationId { get; set; }
}