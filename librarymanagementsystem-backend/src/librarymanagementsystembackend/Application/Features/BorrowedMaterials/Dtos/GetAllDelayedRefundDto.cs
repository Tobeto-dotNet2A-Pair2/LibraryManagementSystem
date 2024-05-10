namespace Application.Features.BorrowedMaterials.Dtos;

public class GetAllDelayedRefundDto
{
    public Guid MemberId { get; set; }
    public decimal? TotalDebt { get; set; }
}