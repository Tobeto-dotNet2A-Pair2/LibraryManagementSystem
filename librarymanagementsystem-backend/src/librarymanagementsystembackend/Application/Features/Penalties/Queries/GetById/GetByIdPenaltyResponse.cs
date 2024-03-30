using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Queries.GetById;

public class GetByIdPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public decimal AmountPenalty { get; set; }
    public int DayDelay { get; set; }
    public DateTime FirstDayPunishment { get; set; }
    public decimal TotalPenalty { get; set; }
}