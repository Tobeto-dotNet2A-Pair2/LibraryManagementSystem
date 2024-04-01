using Application.Features.Authors.Commands.Create;
using Application.Features.Authors.Commands.Delete;
using Application.Features.Authors.Commands.Update;
using Application.Features.Authors.Queries.GetById;
using Application.Features.Authors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Authors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Author, CreateAuthorCommand>().ReverseMap();
        CreateMap<Author, CreatedAuthorResponse>().ReverseMap();
        CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
        CreateMap<Author, UpdatedAuthorResponse>().ReverseMap();
        CreateMap<Author, DeleteAuthorCommand>().ReverseMap();
        CreateMap<Author, DeletedAuthorResponse>().ReverseMap();
        CreateMap<Author, GetByIdAuthorResponse>().ReverseMap();
        CreateMap<Author, GetListAuthorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Author>, GetListResponse<GetListAuthorListItemDto>>().ReverseMap();
    }
}