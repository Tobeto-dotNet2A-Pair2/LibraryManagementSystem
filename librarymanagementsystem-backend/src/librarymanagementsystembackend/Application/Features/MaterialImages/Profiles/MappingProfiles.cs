using Application.Features.MaterialImages.Commands.Create;
using Application.Features.MaterialImages.Commands.Delete;
using Application.Features.MaterialImages.Commands.Update;
using Application.Features.MaterialImages.Dtos;
using Application.Features.MaterialImages.Queries.GetById;
using Application.Features.MaterialImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialImage, CreateMaterialImageCommand>().ReverseMap();
        CreateMap<MaterialImage, CreatedMaterialImageResponse>().ReverseMap();
        CreateMap<MaterialImage, UpdateMaterialImageCommand>().ReverseMap();
        CreateMap<MaterialImage, UpdatedMaterialImageResponse>().ReverseMap();
        CreateMap<MaterialImage, DeleteMaterialImageCommand>().ReverseMap();
        CreateMap<MaterialImage, DeletedMaterialImageResponse>().ReverseMap();
        CreateMap<MaterialImage, GetByIdMaterialImageResponse>().ReverseMap();
        CreateMap<MaterialImage, GetListMaterialImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialImage>, GetListResponse<GetListMaterialImageListItemDto>>().ReverseMap();

        CreateMap<MaterialImage, MaterialImageForMaterialDetailDto>();
    }
}