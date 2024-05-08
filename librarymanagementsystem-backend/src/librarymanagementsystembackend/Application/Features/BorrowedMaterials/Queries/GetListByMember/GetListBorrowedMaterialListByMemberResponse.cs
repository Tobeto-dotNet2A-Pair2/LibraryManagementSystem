using Application.Features.Materials.Dtos;

namespace Application.Features.BorrowedMaterials.Queries.GetListByMember;

public class GetListBorrowedMaterialListByMemberResponse
{
    public GetListBorrowedMaterialListByMemberResponse()
    {
        
    }
    public MaterialForListBorrowedMaterialDto Material { get; set; }
    public int DelayDay { get; set; }
    public int DaysToRefund { get; set; }
    public decimal TotalDept { get; set; }
}


