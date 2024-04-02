using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreatedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }
}