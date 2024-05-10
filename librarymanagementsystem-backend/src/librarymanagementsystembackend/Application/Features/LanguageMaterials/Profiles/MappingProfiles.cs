using Application.Features.LanguageMaterials.Commands.Create;
using Application.Features.LanguageMaterials.Commands.Delete;
using Application.Features.LanguageMaterials.Commands.Update;
using Application.Features.LanguageMaterials.Queries.GetById;
using Application.Features.LanguageMaterials.Queries.GetList;
using Application.Features.Languages.Dtos;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LanguageMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LanguageMaterial, CreateLanguageMaterialCommand>().ReverseMap();
        CreateMap<LanguageMaterial, CreatedLanguageMaterialResponse>().ReverseMap();
        CreateMap<LanguageMaterial, UpdateLanguageMaterialCommand>().ReverseMap();
        CreateMap<LanguageMaterial, UpdatedLanguageMaterialResponse>().ReverseMap();
        CreateMap<LanguageMaterial, DeleteLanguageMaterialCommand>().ReverseMap();
        CreateMap<LanguageMaterial, DeletedLanguageMaterialResponse>().ReverseMap();
        CreateMap<LanguageMaterial, GetByIdLanguageMaterialResponse>().ReverseMap();
        CreateMap<LanguageMaterial, GetListLanguageMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<LanguageMaterial>, GetListResponse<GetListLanguageMaterialListItemDto>>().ReverseMap();

        CreateMap<LanguageMaterial, LanguageForMaterialDetailDto>()
            .ForMember(a => a.Name, opt => opt
                .MapFrom(src => src.Language.Name));
    }
}