using Application.Features.MaterialProperties.Commands.Create;
using Application.Features.MaterialProperties.Commands.Delete;
using Application.Features.MaterialProperties.Commands.Update;
using Application.Features.MaterialProperties.Queries.GetById;
using Application.Features.MaterialProperties.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialProperties.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialProperty, CreateMaterialPropertyCommand>().ReverseMap();
        CreateMap<MaterialProperty, CreatedMaterialPropertyResponse>().ReverseMap();
        CreateMap<MaterialProperty, UpdateMaterialPropertyCommand>().ReverseMap();
        CreateMap<MaterialProperty, UpdatedMaterialPropertyResponse>().ReverseMap();
        CreateMap<MaterialProperty, DeleteMaterialPropertyCommand>().ReverseMap();
        CreateMap<MaterialProperty, DeletedMaterialPropertyResponse>().ReverseMap();
        CreateMap<MaterialProperty, GetByIdMaterialPropertyResponse>().ReverseMap();
        CreateMap<MaterialProperty, GetListMaterialPropertyListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialProperty>, GetListResponse<GetListMaterialPropertyListItemDto>>().ReverseMap();
    }
}