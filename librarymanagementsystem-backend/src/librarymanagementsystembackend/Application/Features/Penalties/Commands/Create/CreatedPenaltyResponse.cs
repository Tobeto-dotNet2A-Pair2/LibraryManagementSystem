using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Commands.Create;

public class CreatedPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public decimal? TotalMaterialPenalty { get; set; }
    public int DayDelay { get; set; }
    public Guid NotificationId { get; set; }
    public Guid BorrowedMaterialId { get; set; }
}