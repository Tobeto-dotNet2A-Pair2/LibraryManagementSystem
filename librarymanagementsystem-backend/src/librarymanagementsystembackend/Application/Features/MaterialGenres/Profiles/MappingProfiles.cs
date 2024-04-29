using Application.Features.MaterialGenres.Commands.Create;
using Application.Features.MaterialGenres.Commands.Delete;
using Application.Features.MaterialGenres.Commands.Update;
using Application.Features.MaterialGenres.Queries.GetById;
using Application.Features.MaterialGenres.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialGenres.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialGenre, CreateMaterialGenreCommand>().ReverseMap();
        CreateMap<MaterialGenre, CreatedMaterialGenreResponse>().ReverseMap();
        CreateMap<MaterialGenre, UpdateMaterialGenreCommand>().ReverseMap();
        CreateMap<MaterialGenre, UpdatedMaterialGenreResponse>().ReverseMap();
        CreateMap<MaterialGenre, DeleteMaterialGenreCommand>().ReverseMap();
        CreateMap<MaterialGenre, DeletedMaterialGenreResponse>().ReverseMap();
        CreateMap<MaterialGenre, GetByIdMaterialGenreResponse>().ReverseMap();
        CreateMap<MaterialGenre, GetListMaterialGenreListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialGenre>, GetListResponse<GetListMaterialGenreListItemDto>>().ReverseMap();
    }
}