using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdatedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }
}