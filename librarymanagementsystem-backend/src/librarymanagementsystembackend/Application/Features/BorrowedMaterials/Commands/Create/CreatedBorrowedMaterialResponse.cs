using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreatedBorrowedMaterialResponse : IResponse
{
    public DateTime ReturnDate { get; set; }
    public DateTime BorrowedDate { get; set; }
    public decimal PunishmentAmount { get; set; }
}