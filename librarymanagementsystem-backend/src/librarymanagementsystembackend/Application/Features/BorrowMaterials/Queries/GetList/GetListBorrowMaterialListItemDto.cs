using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BorrowMaterials.Queries.GetList;

public class GetListBorrowMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid MemberId { get; set; }
}