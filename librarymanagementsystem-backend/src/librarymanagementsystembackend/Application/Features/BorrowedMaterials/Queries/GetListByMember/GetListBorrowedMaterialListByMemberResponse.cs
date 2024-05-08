using Application.Features.Authors.Dtos;
using Application.Features.MaterialImages.Dtos;
using Application.Features.MaterialProperties.Dtos;
using Application.Features.MaterialPropertyValues.Dtos;

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

public class MaterialForListBorrowedMaterialDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<AuthorMaterialListForBorrowedMaterialDto> AuthorMaterials { get; set; }
    public List<MaterialImageForListBorrowedMaterialDto> MaterialImages { get; set; }
    public List<MaterialPropertyValuesListForBorrowedMaterialDto> MaterialPropertyValues { get; set; }

}

public class MaterialCopyForListBorrowedMaterialDto
{
    public Guid Id { get; set; }
    public bool IsReserved { get; set; }
    public bool IsReservable { get; set; } 
}

