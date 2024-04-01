using Application.Features.Publishers.Commands.Create;
using Application.Features.Publishers.Commands.Delete;
using Application.Features.Publishers.Commands.Update;
using Application.Features.Publishers.Queries.GetById;
using Application.Features.Publishers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Publishers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Publisher, CreatePublisherCommand>().ReverseMap();
        CreateMap<Publisher, CreatedPublisherResponse>().ReverseMap();
        CreateMap<Publisher, UpdatePublisherCommand>().ReverseMap();
        CreateMap<Publisher, UpdatedPublisherResponse>().ReverseMap();
        CreateMap<Publisher, DeletePublisherCommand>().ReverseMap();
        CreateMap<Publisher, DeletedPublisherResponse>().ReverseMap();
        CreateMap<Publisher, GetByIdPublisherResponse>().ReverseMap();
        CreateMap<Publisher, GetListPublisherListItemDto>().ReverseMap();
        CreateMap<IPaginate<Publisher>, GetListResponse<GetListPublisherListItemDto>>().ReverseMap();
    }
}