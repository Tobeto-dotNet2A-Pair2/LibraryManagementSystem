using Application.Features.Streets.Commands.Create;
using Application.Features.Streets.Commands.Delete;
using Application.Features.Streets.Commands.Update;
using Application.Features.Streets.Queries.GetById;
using Application.Features.Streets.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Streets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Street, CreateStreetCommand>().ReverseMap();
        CreateMap<Street, CreatedStreetResponse>().ReverseMap();
        CreateMap<Street, UpdateStreetCommand>().ReverseMap();
        CreateMap<Street, UpdatedStreetResponse>().ReverseMap();
        CreateMap<Street, DeleteStreetCommand>().ReverseMap();
        CreateMap<Street, DeletedStreetResponse>().ReverseMap();
        CreateMap<Street, GetByIdStreetResponse>().ReverseMap();
        CreateMap<Street, GetListStreetListItemDto>().ReverseMap();
        CreateMap<IPaginate<Street>, GetListResponse<GetListStreetListItemDto>>().ReverseMap();
    }
}