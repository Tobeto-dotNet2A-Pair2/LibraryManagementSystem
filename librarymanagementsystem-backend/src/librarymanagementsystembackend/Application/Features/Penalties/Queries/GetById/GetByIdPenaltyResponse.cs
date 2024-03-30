using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Queries.GetById;

public class GetByIdPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public int DayDelay { get; set; }
    public decimal TotalMaterialPenalty { get; set; }
    public Guid BorrowMaterialId { get; set; }
}