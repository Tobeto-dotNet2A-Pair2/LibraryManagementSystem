using Application.Features.BorrowMaterials.Commands.Create;
using Application.Features.BorrowMaterials.Commands.Delete;
using Application.Features.BorrowMaterials.Commands.Update;
using Application.Features.BorrowMaterials.Queries.GetById;
using Application.Features.BorrowMaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BorrowMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BorrowMaterial, CreateBorrowMaterialCommand>().ReverseMap();
        CreateMap<BorrowMaterial, CreatedBorrowMaterialResponse>().ReverseMap();
        CreateMap<BorrowMaterial, UpdateBorrowMaterialCommand>().ReverseMap();
        CreateMap<BorrowMaterial, UpdatedBorrowMaterialResponse>().ReverseMap();
        CreateMap<BorrowMaterial, DeleteBorrowMaterialCommand>().ReverseMap();
        CreateMap<BorrowMaterial, DeletedBorrowMaterialResponse>().ReverseMap();
        CreateMap<BorrowMaterial, GetByIdBorrowMaterialResponse>().ReverseMap();
        CreateMap<BorrowMaterial, GetListBorrowMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<BorrowMaterial>, GetListResponse<GetListBorrowMaterialListItemDto>>().ReverseMap();
    }
}