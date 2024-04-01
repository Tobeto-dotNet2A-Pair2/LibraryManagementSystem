using Application.Features.Locations.Commands.Create;
using Application.Features.Locations.Commands.Delete;
using Application.Features.Locations.Commands.Update;
using Application.Features.Locations.Queries.GetById;
using Application.Features.Locations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Locations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Location, CreateLocationCommand>().ReverseMap();
        CreateMap<Location, CreatedLocationResponse>().ReverseMap();
        CreateMap<Location, UpdateLocationCommand>().ReverseMap();
        CreateMap<Location, UpdatedLocationResponse>().ReverseMap();
        CreateMap<Location, DeleteLocationCommand>().ReverseMap();
        CreateMap<Location, DeletedLocationResponse>().ReverseMap();
        CreateMap<Location, GetByIdLocationResponse>().ReverseMap();
        CreateMap<Location, GetListLocationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Location>, GetListResponse<GetListLocationListItemDto>>().ReverseMap();
    }
}