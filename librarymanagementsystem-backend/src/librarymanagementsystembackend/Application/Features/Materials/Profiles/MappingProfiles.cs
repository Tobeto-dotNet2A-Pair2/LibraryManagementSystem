using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.Materials.Queries.GetById;
using Application.Features.Materials.Queries.GetById.GetDetails;
using Application.Features.Materials.Queries.GetList;
using Application.Features.Materials.Queries.GetList.GetAllForAdmin;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.MaterialImages.Queries.GetList;

namespace Application.Features.Materials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Material, CreateMaterialCommand>().ReverseMap();
        CreateMap<Material, CreatedMaterialResponse>().ReverseMap();
        CreateMap<Material, UpdateMaterialCommand>().ReverseMap();
        CreateMap<Material, UpdatedMaterialResponse>().ReverseMap();
        CreateMap<Material, DeleteMaterialCommand>().ReverseMap();
        CreateMap<Material, DeletedMaterialResponse>().ReverseMap();
        CreateMap<Material, GetByIdMaterialResponse>().ReverseMap();
        CreateMap<Material, GetListMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<Material>, GetListResponse<GetListMaterialListItemDto>>().ReverseMap();

        //1.deneme=List----burada  MaterialImages tüm tabloyu cýktý olarak veriyordu
        //CreateMap<MaterialImage, GetListMaterialImageListItemDto>().ReverseMap(); // MaterialImage ile DTO arasýnda mapping
        //CreateMap<Material, GetListMaterialListItemDto>()
        //    .ForMember(dest => dest.MaterialImages, opt => opt.MapFrom(src => src.MaterialImages)) // MaterialImages özelliði ile eþleme
        //    .ReverseMap();

        //2.deneme=List---dogru cýktý veriyor
        CreateMap<MaterialImage, GetListMaterialImageListItemDto>().ReverseMap(); // MaterialImage ile DTO arasýnda mapping
        CreateMap<Material, GetListMaterialListItemDto>()
      .ForMember(x => x.ImageUrls,
               src => src
                   .MapFrom(a => a.MaterialImages
                       .Select(b => b.Url)));

        //ebrudan gelen-------------------------------
        CreateMap<Material, GetAllMaterialListAdminDto>()
            .ForMember(x => x.ImageUrls,
                src => src
                    .MapFrom(a => a.MaterialImages
                        .Select(b => b.Url)));

        CreateMap<Material, GetDetailByIdForAdminDto>()
            .ForMember(src => src.Authors,
                opt => opt
                    .MapFrom(dest => dest.AuthorMaterials.Select(a => a.Author)))

            .ForMember(src => src.Publishers,
                opt => opt
                    .MapFrom(dest => dest.PublisherMaterials.Select(a => a.Publisher)))

            .ForMember(src => src.Languages,
                opt => opt
                    .MapFrom(dest => dest.LanguageMaterials.Select(a => a.Language)))

            .ForMember(src => src.Translators,
                opt => opt
                    .MapFrom(dest => dest.TranslatorMaterials.Select(a => a.Translator)))

            .ForMember(src => src.MaterialCopies,
                opt => opt
                    .MapFrom(dest => dest.MaterialCopies))

            .ForMember(src => src.Genres,
                opt => opt
                    .MapFrom(dest => dest.MaterialGenres.Select(a => a.Genre)))

            .ForMember(src => src.MaterialProperties,
                opt => opt
                    .MapFrom(dest => dest.MaterialPropertyValues.Select(a => a.MaterialProperty)));

    }
}