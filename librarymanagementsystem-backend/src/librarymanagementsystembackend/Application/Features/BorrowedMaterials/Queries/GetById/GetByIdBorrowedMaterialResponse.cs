using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Queries.GetById;

public class GetByIdBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}