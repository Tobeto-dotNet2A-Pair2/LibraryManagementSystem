using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.Materials.Queries.GetById;
using Application.Features.Materials.Queries.GetById.GetDetails;
using Application.Features.Materials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

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