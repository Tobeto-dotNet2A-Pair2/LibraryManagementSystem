using Application.Features.TranslatorMaterials.Commands.Create;
using Application.Features.TranslatorMaterials.Commands.Delete;
using Application.Features.TranslatorMaterials.Commands.Update;
using Application.Features.TranslatorMaterials.Queries.GetById;
using Application.Features.TranslatorMaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TranslatorMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TranslatorMaterial, CreateTranslatorMaterialCommand>().ReverseMap();
        CreateMap<TranslatorMaterial, CreatedTranslatorMaterialResponse>().ReverseMap();
        CreateMap<TranslatorMaterial, UpdateTranslatorMaterialCommand>().ReverseMap();
        CreateMap<TranslatorMaterial, UpdatedTranslatorMaterialResponse>().ReverseMap();
        CreateMap<TranslatorMaterial, DeleteTranslatorMaterialCommand>().ReverseMap();
        CreateMap<TranslatorMaterial, DeletedTranslatorMaterialResponse>().ReverseMap();
        CreateMap<TranslatorMaterial, GetByIdTranslatorMaterialResponse>().ReverseMap();
        CreateMap<TranslatorMaterial, GetListTranslatorMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<TranslatorMaterial>, GetListResponse<GetListTranslatorMaterialListItemDto>>().ReverseMap();
    }
}