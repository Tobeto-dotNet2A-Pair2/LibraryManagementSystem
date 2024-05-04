namespace Application.Features.Penalties.Dto;

public class CreatePenaltyWhenRefundDto
{
    public Guid BorrowedMaterialId { get; set; }
    public int DayDelay { get; set; }
    public decimal TotalMaterialDebt { get; set; }
}