using Application.Features.BorrowedMaterials.Queries.GetListByMember;
using Application.Features.MaterialProperties.Dtos;
using Application.Features.MaterialPropertyValues.Commands.Create;
using Application.Features.MaterialPropertyValues.Commands.Delete;
using Application.Features.MaterialPropertyValues.Commands.Update;
using Application.Features.MaterialPropertyValues.Dtos;
using Application.Features.MaterialPropertyValues.Queries.GetById;
using Application.Features.MaterialPropertyValues.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialPropertyValues.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialPropertyValue, CreateMaterialPropertyValueCommand>().ReverseMap();
        CreateMap<MaterialPropertyValue, CreatedMaterialPropertyValueResponse>().ReverseMap();
        CreateMap<MaterialPropertyValue, UpdateMaterialPropertyValueCommand>().ReverseMap();
        CreateMap<MaterialPropertyValue, UpdatedMaterialPropertyValueResponse>().ReverseMap();
        CreateMap<MaterialPropertyValue, DeleteMaterialPropertyValueCommand>().ReverseMap();
        CreateMap<MaterialPropertyValue, DeletedMaterialPropertyValueResponse>().ReverseMap();
        CreateMap<MaterialPropertyValue, GetByIdMaterialPropertyValueResponse>().ReverseMap();
        CreateMap<MaterialPropertyValue, GetListMaterialPropertyValueListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialPropertyValue>, GetListResponse<GetListMaterialPropertyValueListItemDto>>()
            .ReverseMap();

        CreateMap<MaterialPropertyValue, MaterialPropertyValuesForMaterialDetailDto>();

        CreateMap<MaterialPropertyValue, MaterialPropertyValuesListForBorrowedMaterialDto>();
    }
}