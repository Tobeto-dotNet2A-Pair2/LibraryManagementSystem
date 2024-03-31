using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreatedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}