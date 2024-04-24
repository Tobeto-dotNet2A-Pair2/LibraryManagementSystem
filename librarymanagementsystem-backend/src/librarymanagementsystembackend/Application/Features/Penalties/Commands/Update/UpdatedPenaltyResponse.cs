using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatedPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public decimal TotalMaterialDebt { get; set; }
    public int DayDelay { get; set; }
    public Guid BorrowedMaterialId { get; set; }
}