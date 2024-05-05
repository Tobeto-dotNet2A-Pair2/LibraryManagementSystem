using Application.Features.Authors.Dtos;
using Application.Features.Branches.Dtos;
using Application.Features.Genres.Dtos;
using Application.Features.Languages.Dtos;
using Application.Features.Locations.Dtos;
using Application.Features.MaterialCopies.Dtos;
using Application.Features.MaterialProperties.Dtos;
using Application.Features.MaterialTypes.Dtos;
using Application.Features.Publishers.Dtos;
using Application.Features.Translators.Dtos;

namespace Application.Features.Materials.Queries.GetById.GetDetails;

public class GetDetailByIdForAdminDto
{
    public List<AuthorForMaterialDetailDto> Authors { get; set; }
    public List<PublisherForMaterialDetailDto> Publishers { get; set; }
    public List<LanguageForMaterialDetailDto> Languages { get; set; }
    public List<TranslatorForMaterialDetailDto> Translators { get; set; }
    public List<MaterialCopyForMaterialDetailDto> MaterialCopies { get; set; }
    public List<GenreForMaterialDetailDto> Genres { get; set; }
    public List<MaterialPropertyForMaterialDetailDto> MaterialProperties { get; set; }
    
   
}

