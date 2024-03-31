using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialCopies.Queries.GetList;

public class GetListMaterialCopyListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime DateReceipt { get; set; }
    public string Status { get; set; }
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid LocationId { get; set; }
}