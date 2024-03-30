using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowMaterials.Commands.Update;

public class UpdatedBorrowMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid MemberId { get; set; }
}