using Application.Features.BorrowedMaterials.Commands.Create;
using Application.Features.BorrowedMaterials.Commands.Delete;
using Application.Features.BorrowedMaterials.Commands.Update;
using Application.Features.BorrowedMaterials.Queries.GetById;
using Application.Features.BorrowedMaterials.Queries.GetList;
using Application.Features.BorrowedMaterials.Queries.GetListByMember;
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

        CreateMap<CreateBorrowedMaterialCommand, BorrowedMaterial>()
            .ForMember(a => a.BorrowedDate, opt => opt
                .MapFrom(src => DateTime.UtcNow));

        CreateMap<BorrowedMaterial, CreatedBorrowedMaterialResponse>();

        CreateMap<BorrowedMaterial, GetListBorrowedMaterialListByMemberResponse>()
            .ForMember(a => a.MaterialCopy, opt => opt
                .MapFrom(src => src.MaterialCopy))

            .ForMember(a => a.Material, opt => opt
                .MapFrom(src => src.MaterialCopy.Material))

            .ForMember(a => a.DelayDay, opt => opt
                .MapFrom(src =>
                    (DateTime.UtcNow - src.ReturnDate).Days > 0 ? (DateTime.UtcNow - src.ReturnDate).Days : 0))

            .ForMember(a => a.DaysToRefund, opt => opt
                .MapFrom(src => (DateTime.UtcNow - src.ReturnDate).Days * -1))

            .ForMember(a => a.MaterialImages, opt => opt
                .MapFrom(src => src.MaterialCopy.Material.MaterialImages))

            .ForMember(a => a.MaterialPropertyValues, opt => opt
                .MapFrom(src => src.MaterialCopy.Material.MaterialPropertyValues))

            .ForMember(a => a.AuthorMaterials, opt => opt
                .MapFrom(src => src.MaterialCopy.Material.AuthorMaterials));
        
            CreateMap<MaterialImage, MaterialImageForListBorrowedMaterialDto>();
    }
}