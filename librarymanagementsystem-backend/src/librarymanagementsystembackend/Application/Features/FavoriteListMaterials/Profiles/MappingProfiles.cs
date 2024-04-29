using Application.Features.FavoriteListMaterials.Commands.Create;
using Application.Features.FavoriteListMaterials.Commands.Delete;
using Application.Features.FavoriteListMaterials.Commands.Update;
using Application.Features.FavoriteListMaterials.Queries.GetById;
using Application.Features.FavoriteListMaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FavoriteListMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FavoriteListMaterial, CreateFavoriteListMaterialCommand>().ReverseMap();
        CreateMap<FavoriteListMaterial, CreatedFavoriteListMaterialResponse>().ReverseMap();
        CreateMap<FavoriteListMaterial, UpdateFavoriteListMaterialCommand>().ReverseMap();
        CreateMap<FavoriteListMaterial, UpdatedFavoriteListMaterialResponse>().ReverseMap();
        CreateMap<FavoriteListMaterial, DeleteFavoriteListMaterialCommand>().ReverseMap();
        CreateMap<FavoriteListMaterial, DeletedFavoriteListMaterialResponse>().ReverseMap();
        CreateMap<FavoriteListMaterial, GetByIdFavoriteListMaterialResponse>().ReverseMap();
        CreateMap<FavoriteListMaterial, GetListFavoriteListMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<FavoriteListMaterial>, GetListResponse<GetListFavoriteListMaterialListItemDto>>().ReverseMap();
    }
}