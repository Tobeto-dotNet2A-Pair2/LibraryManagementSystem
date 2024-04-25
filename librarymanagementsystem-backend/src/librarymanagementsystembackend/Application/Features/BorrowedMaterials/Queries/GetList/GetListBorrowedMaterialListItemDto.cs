using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BorrowedMaterials.Queries.GetList;

public class GetListBorrowedMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }
}