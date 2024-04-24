using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Queries.GetById;

public class GetByIdBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }
}