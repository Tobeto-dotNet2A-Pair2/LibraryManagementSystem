using Application.Features.MaterialPropertyValues.Dtos;

namespace Application.Features.MaterialProperties.Dtos;

public class MaterialPropertyForMaterialDetailDto
{
    public string Name { get; set; }
    public MaterialPropertyValuesForMaterialDetailDto PropertyValue { get; set; }
}

