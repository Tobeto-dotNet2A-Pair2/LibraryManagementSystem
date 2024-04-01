using Application.Features.MaterialTypes.Commands.Create;
using Application.Features.MaterialTypes.Commands.Delete;
using Application.Features.MaterialTypes.Commands.Update;
using Application.Features.MaterialTypes.Queries.GetById;
using Application.Features.MaterialTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialType, CreateMaterialTypeCommand>().ReverseMap();
        CreateMap<MaterialType, CreatedMaterialTypeResponse>().ReverseMap();
        CreateMap<MaterialType, UpdateMaterialTypeCommand>().ReverseMap();
        CreateMap<MaterialType, UpdatedMaterialTypeResponse>().ReverseMap();
        CreateMap<MaterialType, DeleteMaterialTypeCommand>().ReverseMap();
        CreateMap<MaterialType, DeletedMaterialTypeResponse>().ReverseMap();
        CreateMap<MaterialType, GetByIdMaterialTypeResponse>().ReverseMap();
        CreateMap<MaterialType, GetListMaterialTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialType>, GetListResponse<GetListMaterialTypeListItemDto>>().ReverseMap();
    }
}