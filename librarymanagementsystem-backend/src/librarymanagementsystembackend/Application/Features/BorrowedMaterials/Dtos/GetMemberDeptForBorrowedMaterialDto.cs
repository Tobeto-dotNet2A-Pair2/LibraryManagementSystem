namespace Application.Features.BorrowedMaterials.Dtos;

public class GetMemberDeptForBorrowedMaterialDto
{
    public int DelayDay { get; set; }
    public decimal TotalDebt { get; set; }
}