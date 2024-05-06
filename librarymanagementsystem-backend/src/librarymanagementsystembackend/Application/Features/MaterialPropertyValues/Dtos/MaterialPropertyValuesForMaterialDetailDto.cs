using Application.Features.MaterialTypes.Dtos;

namespace Application.Features.MaterialPropertyValues.Dtos;

public class MaterialPropertyValuesForMaterialDetailDto
{
    public string Content { get; set; }
    public MaterialTypeForMaterialDetailDto MaterialType { get; set; }
}
