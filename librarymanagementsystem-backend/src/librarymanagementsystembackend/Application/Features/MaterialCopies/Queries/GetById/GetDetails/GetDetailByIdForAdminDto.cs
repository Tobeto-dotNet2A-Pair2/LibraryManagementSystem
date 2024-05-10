using Application.Features.Authors.Dtos;
using Application.Features.Genres.Dtos;
using Application.Features.Languages.Dtos;
using Application.Features.MaterialCopies.Dtos;
using Application.Features.MaterialImages.Dtos;
using Application.Features.MaterialProperties.Dtos;
using Application.Features.Publishers.Dtos;
using Application.Features.Translators.Dtos;

namespace Application.Features.MaterialCopies.Queries.GetById.GetDetails;

public class GetDetailByIdForAdminDto
{
        public GetDetailByIdForAdminDto()
        {
        
        }
        
        public Guid Id { get; set; }
        public string Status { get; set; }
        public bool IsReserved { get; set; }
        public bool IsReservable { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PunishmentAmount { get; set; }
        public bool IsBorrowable { get; set; }
        public byte BorrowDay { get; set; }

        public List<AuthorForMaterialDetailDto> Authors { get; set; }
        public List<PublisherForMaterialDetailDto> Publishers { get; set; }
        public List<LanguageForMaterialDetailDto> Languages { get; set; }
        public List<TranslatorForMaterialDetailDto> Translators { get; set; }
        public List<GenreForMaterialDetailDto> Genres { get; set; }
        public List<MaterialPropertyForMaterialDetailDto> MaterialProperties { get; set; }
        public List<MaterialImageForMaterialDetailDto> MaterialImages { get; set; }


        //TODO: LocationMap  ve Branch bilgisi  gelmiyor: Material Copyden gelmesi  gerekiyor
    
   
}

public class MaterialForMaterialDetailDto
{
   
}
    