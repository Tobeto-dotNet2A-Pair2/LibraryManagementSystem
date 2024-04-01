using Application.Features.BorrowedMaterials.Commands.Create;
using Application.Features.BorrowedMaterials.Commands.Delete;
using Application.Features.BorrowedMaterials.Commands.Update;
using Application.Features.BorrowedMaterials.Queries.GetById;
using Application.Features.BorrowedMaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BorrowedMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BorrowedMaterial, CreateBorrowedMaterialCommand>().ReverseMap();
        CreateMap<BorrowedMaterial, CreatedBorrowedMaterialResponse>().ReverseMap();
        CreateMap<BorrowedMaterial, UpdateBorrowedMaterialCommand>().ReverseMap();
        CreateMap<BorrowedMaterial, UpdatedBorrowedMaterialResponse>().ReverseMap();
        CreateMap<BorrowedMaterial, DeleteBorrowedMaterialCommand>().ReverseMap();
        CreateMap<BorrowedMaterial, DeletedBorrowedMaterialResponse>().ReverseMap();
        CreateMap<BorrowedMaterial, GetByIdBorrowedMaterialResponse>().ReverseMap();
        CreateMap<BorrowedMaterial, GetListBorrowedMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<BorrowedMaterial>, GetListResponse<GetListBorrowedMaterialListItemDto>>().ReverseMap();
    }
}