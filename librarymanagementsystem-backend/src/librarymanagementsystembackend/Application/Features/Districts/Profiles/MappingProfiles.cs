using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Districts.Queries.GetDynamic;

namespace Application.Features.Districts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<District, CreateDistrictCommand>().ReverseMap();
        CreateMap<District, CreatedDistrictResponse>().ReverseMap();
        CreateMap<District, UpdateDistrictCommand>().ReverseMap();
        CreateMap<District, UpdatedDistrictResponse>().ReverseMap();
        CreateMap<District, DeleteDistrictCommand>().ReverseMap();
        CreateMap<District, DeletedDistrictResponse>().ReverseMap();
        CreateMap<District, GetByIdDistrictResponse>().ReverseMap();
        CreateMap<District, GetListDistrictListItemDto>().ReverseMap();
        CreateMap<IPaginate<District>, GetListResponse<GetListDistrictListItemDto>>().ReverseMap();

        CreateMap<District, GetDynamicDistrictResponse>().ReverseMap();
        CreateMap<IPaginate<District>, GetListResponse<GetDynamicDistrictResponse>>().ReverseMap();

    }
}