using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdatedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}