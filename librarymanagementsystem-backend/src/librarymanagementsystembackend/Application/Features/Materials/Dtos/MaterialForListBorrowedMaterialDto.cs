using Application.Features.Authors.Dtos;
using Application.Features.MaterialImages.Dtos;
using Application.Features.MaterialPropertyValues.Dtos;

namespace Application.Features.Materials.Dtos;

public class MaterialForListBorrowedMaterialDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<AuthorMaterialListForBorrowedMaterialDto> AuthorMaterials { get; set; }
    public List<MaterialImageForListBorrowedMaterialDto> MaterialImages { get; set; }
    public List<MaterialPropertyValuesListForBorrowedMaterialDto> MaterialPropertyValues { get; set; }
}
