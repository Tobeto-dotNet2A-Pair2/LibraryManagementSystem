using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Penalties.Queries.GetList;

public class GetListPenaltyListItemDto : IDto
{
    public Guid Id { get; set; }
    public decimal? TotalMaterialPenalty { get; set; }
    public int DayDelay { get; set; }
    public Guid NotificationId { get; set; }
    public Guid BorrowedMaterialId { get; set; }
}