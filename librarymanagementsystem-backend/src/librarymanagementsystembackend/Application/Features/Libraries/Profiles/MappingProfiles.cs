using Application.Features.Libraries.Commands.Create;
using Application.Features.Libraries.Commands.Delete;
using Application.Features.Libraries.Commands.Update;
using Application.Features.Libraries.Queries.GetById;
using Application.Features.Libraries.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Libraries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Library, CreateLibraryCommand>().ReverseMap();
        CreateMap<Library, CreatedLibraryResponse>().ReverseMap();
        CreateMap<Library, UpdateLibraryCommand>().ReverseMap();
        CreateMap<Library, UpdatedLibraryResponse>().ReverseMap();
        CreateMap<Library, DeleteLibraryCommand>().ReverseMap();
        CreateMap<Library, DeletedLibraryResponse>().ReverseMap();
        CreateMap<Library, GetByIdLibraryResponse>().ReverseMap();
        CreateMap<Library, GetListLibraryListItemDto>().ReverseMap();
        CreateMap<IPaginate<Library>, GetListResponse<GetListLibraryListItemDto>>().ReverseMap();
    }
}