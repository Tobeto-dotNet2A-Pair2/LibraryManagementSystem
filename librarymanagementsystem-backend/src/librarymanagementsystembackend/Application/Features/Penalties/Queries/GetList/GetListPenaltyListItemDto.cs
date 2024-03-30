using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Penalties.Queries.GetList;

public class GetListPenaltyListItemDto : IDto
{
    public Guid Id { get; set; }
    public decimal AmountPenalty { get; set; }
    public int DayDelay { get; set; }
    public DateTime FirstDayPunishment { get; set; }
    public decimal TotalPenalty { get; set; }
}