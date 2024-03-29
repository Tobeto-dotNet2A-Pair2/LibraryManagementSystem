using Application.Features.FavoriteLists.Commands.Create;
using Application.Features.FavoriteLists.Commands.Delete;
using Application.Features.FavoriteLists.Commands.Update;
using Application.Features.FavoriteLists.Queries.GetById;
using Application.Features.FavoriteLists.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FavoriteLists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FavoriteList, CreateFavoriteListCommand>().ReverseMap();
        CreateMap<FavoriteList, CreatedFavoriteListResponse>().ReverseMap();
        CreateMap<FavoriteList, UpdateFavoriteListCommand>().ReverseMap();
        CreateMap<FavoriteList, UpdatedFavoriteListResponse>().ReverseMap();
        CreateMap<FavoriteList, DeleteFavoriteListCommand>().ReverseMap();
        CreateMap<FavoriteList, DeletedFavoriteListResponse>().ReverseMap();
        CreateMap<FavoriteList, GetByIdFavoriteListResponse>().ReverseMap();
        CreateMap<FavoriteList, GetListFavoriteListListItemDto>().ReverseMap();
        CreateMap<IPaginate<FavoriteList>, GetListResponse<GetListFavoriteListListItemDto>>().ReverseMap();
    }
}