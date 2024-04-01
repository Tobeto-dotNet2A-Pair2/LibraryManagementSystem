using Application.Features.Penalties.Commands.Create;
using Application.Features.Penalties.Commands.Delete;
using Application.Features.Penalties.Commands.Update;
using Application.Features.Penalties.Queries.GetById;
using Application.Features.Penalties.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Penalties.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Penalty, CreatePenaltyCommand>().ReverseMap();
        CreateMap<Penalty, CreatedPenaltyResponse>().ReverseMap();
        CreateMap<Penalty, UpdatePenaltyCommand>().ReverseMap();
        CreateMap<Penalty, UpdatedPenaltyResponse>().ReverseMap();
        CreateMap<Penalty, DeletePenaltyCommand>().ReverseMap();
        CreateMap<Penalty, DeletedPenaltyResponse>().ReverseMap();
        CreateMap<Penalty, GetByIdPenaltyResponse>().ReverseMap();
        CreateMap<Penalty, GetListPenaltyListItemDto>().ReverseMap();
        CreateMap<IPaginate<Penalty>, GetListResponse<GetListPenaltyListItemDto>>().ReverseMap();
    }
}