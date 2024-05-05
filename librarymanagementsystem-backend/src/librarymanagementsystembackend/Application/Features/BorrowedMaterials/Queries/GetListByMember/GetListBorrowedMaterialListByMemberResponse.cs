namespace Application.Features.BorrowedMaterials.Queries.GetListByMember;

public class GetListBorrowedMaterialListByMemberResponse
{
    public GetListBorrowedMaterialListByMemberResponse()
    {
        
    }
    public MaterialForListBorrowedMaterialDto Material { get; set; }
    public MaterialCopyForListBorrowedMaterialDto MaterialCopy { get; set; }
    
    public List<AuthorMaterialListForBorrowedMaterialDto> AuthorMaterials { get; set; }
    public List<MaterialImageForListBorrowedMaterialDto> MaterialImages { get; set; }
    public List<MaterialPropertyValuesListForBorrowedMaterialDto> MaterialPropertyValues { get; set; }
    public int DelayDay { get; set; }
    public int DaysToRefund { get; set; }
}

public class AuthorMaterialListForBorrowedMaterialDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class MaterialForListBorrowedMaterialDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class MaterialCopyForListBorrowedMaterialDto
{
    public Guid Id { get; set; }
    public bool IsReserved { get; set; }
    public bool IsReservable { get; set; } 
}

public class MaterialImageForListBorrowedMaterialDto
{
    public string Url { get; set; }
}
public class MaterialPropertyValuesListForBorrowedMaterialDto
{
    public MaterialPropertyListForBorrowedMaterialDto MaterialProperty { get; set; }
    public string Content { get; set; }
}

public class MaterialPropertyListForBorrowedMaterialDto
{
    public string Name { get; set; }
}