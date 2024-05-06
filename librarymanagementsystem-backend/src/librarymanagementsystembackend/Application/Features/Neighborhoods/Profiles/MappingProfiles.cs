using Application.Features.Neighborhoods.Commands.Create;
using Application.Features.Neighborhoods.Commands.Delete;
using Application.Features.Neighborhoods.Commands.Update;
using Application.Features.Neighborhoods.Queries.GetById;
using Application.Features.Neighborhoods.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Neighborhoods.Queries.GetDynamic;

namespace Application.Features.Neighborhoods.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Neighborhood, CreateNeighborhoodCommand>().ReverseMap();
        CreateMap<Neighborhood, CreatedNeighborhoodResponse>().ReverseMap();
        CreateMap<Neighborhood, UpdateNeighborhoodCommand>().ReverseMap();
        CreateMap<Neighborhood, UpdatedNeighborhoodResponse>().ReverseMap();
        CreateMap<Neighborhood, DeleteNeighborhoodCommand>().ReverseMap();
        CreateMap<Neighborhood, DeletedNeighborhoodResponse>().ReverseMap();
        CreateMap<Neighborhood, GetByIdNeighborhoodResponse>().ReverseMap();
        CreateMap<Neighborhood, GetListNeighborhoodListItemDto>().ReverseMap();
        CreateMap<IPaginate<Neighborhood>, GetListResponse<GetListNeighborhoodListItemDto>>().ReverseMap();

        CreateMap<Neighborhood, GetDynamicNeighborhoodResponse>().ReverseMap();
        CreateMap<IPaginate<Neighborhood>, GetListResponse<GetDynamicNeighborhoodResponse>>().ReverseMap();
    }
}