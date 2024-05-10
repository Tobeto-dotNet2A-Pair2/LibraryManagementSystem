using Application.Features.MaterialProperties.Dtos;

namespace Application.Features.MaterialPropertyValues.Dtos;

public class MaterialPropertyValuesListForBorrowedMaterialDto
{
    public MaterialPropertyListForBorrowedMaterialDto MaterialProperty { get; set; }
    public string Content { get; set; }
}