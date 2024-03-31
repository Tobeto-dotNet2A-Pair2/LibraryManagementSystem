using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BorrowedMaterials.Queries.GetList;

public class GetListBorrowedMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}