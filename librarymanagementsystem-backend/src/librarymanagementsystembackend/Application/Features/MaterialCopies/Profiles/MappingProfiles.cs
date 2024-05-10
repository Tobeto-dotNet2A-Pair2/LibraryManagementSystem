using Application.Features.BorrowedMaterials.Dtos;
using Application.Features.BorrowedMaterials.Queries.GetListByMember;
using Application.Features.MaterialCopies.Commands.Create;
using Application.Features.MaterialCopies.Commands.Delete;
using Application.Features.MaterialCopies.Commands.Update;
using Application.Features.MaterialCopies.Dtos;
using Application.Features.MaterialCopies.Queries.GetById;
using Application.Features.MaterialCopies.Queries.GetById.GetDetails;
using Application.Features.MaterialCopies.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialCopies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialCopy, CreateMaterialCopyCommand>().ReverseMap();
        CreateMap<MaterialCopy, CreatedMaterialCopyResponse>().ReverseMap();
        CreateMap<MaterialCopy, UpdateMaterialCopyCommand>().ReverseMap();
        CreateMap<MaterialCopy, UpdatedMaterialCopyResponse>().ReverseMap();
        CreateMap<MaterialCopy, DeleteMaterialCopyCommand>().ReverseMap();
        CreateMap<MaterialCopy, DeletedMaterialCopyResponse>().ReverseMap();
        CreateMap<MaterialCopy, GetByIdMaterialCopyResponse>().ReverseMap();
        CreateMap<MaterialCopy, GetListMaterialCopyListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialCopy>, GetListResponse<GetListMaterialCopyListItemDto>>().ReverseMap();

        CreateMap<MaterialCopy, MaterialCopyForMaterialDetailDto>();
        CreateMap<MaterialCopy, GetForBorrowDto>()
            .ForMember(a => a.BorrowDay, opt => opt
                .MapFrom(a => a.Material.BorrowDay))
            .ForMember(a => a.PunishmentAmount, opt => opt
                .MapFrom(a => a.Material.PunishmentAmount))
            .ForMember(a => a.Name, opt => opt
                .MapFrom(a => a.Material.Name));


        CreateMap<IPaginate<MaterialCopy>, GetListResponse<GetListMaterialCopyDto>>();
        CreateMap<MaterialCopy, GetListMaterialCopyDto>()
            .ForMember(a => a.Name, opt => opt
                .MapFrom(src => src.Material.Name))
            .ForMember(a => a.Description, opt => opt
                .MapFrom(src => src.Material.Description))
            .ForMember(a => a.ImageUrls, opt => opt
                .MapFrom(src => src.Material.MaterialImages.Select(a => a.Url)))
            .ForMember(a => a.BorrowDay, opt => opt
                .MapFrom(src => src.Material.BorrowDay))
            .ForMember(a => a.IsBorrowable, opt => opt
                .MapFrom(src => src.Material.IsBorrowable))
            .ForMember(a => a.PunishmentAmount, opt => opt
                .MapFrom(src => src.Material.PunishmentAmount))
            .ForMember(a => a.FullLocationMap, opt => opt
                .MapFrom(src => src.Location.FullLocationMap));


        CreateMap<MaterialCopy, GetDetailByIdForAdminDto>()
            .ForMember(a => a.Name, opt => opt
                .MapFrom(src => src.Material.Name))

            .ForMember(a => a.Description, opt => opt
                .MapFrom(src => src.Material.Description))

            .ForMember(a => a.PunishmentAmount, opt => opt
                .MapFrom(src => src.Material.PunishmentAmount))

            .ForMember(a => a.BorrowDay, opt => opt
                .MapFrom(src => src.Material.BorrowDay))

            .ForMember(a => a.IsBorrowable, opt => opt
                .MapFrom(src => src.Material.BorrowDay))

            .ForMember(a => a.IsBorrowable, opt => opt
                .MapFrom(src => src.Material.IsBorrowable))

            .ForMember(a => a.MaterialImages, opt => opt
                .MapFrom(src => src.Material.MaterialImages))

            .ForMember(a => a.Authors, opt => opt
                .MapFrom(src => src.Material.AuthorMaterials))

            .ForMember(a => a.Genres, opt => opt
                .MapFrom(src => src.Material.MaterialGenres))

            .ForMember(a => a.Publishers, opt => opt
                .MapFrom(src => src.Material.PublisherMaterials))

            .ForMember(a => a.Languages, opt => opt
                .MapFrom(src => src.Material.LanguageMaterials))

            .ForMember(a => a.Translators, opt => opt
                .MapFrom(src => src.Material.TranslatorMaterials))

            .ForMember(src => src.MaterialProperties,
                opt => opt
                    .MapFrom(dest => dest.Material.MaterialPropertyValues.Select(a => a.MaterialProperty)));



    }
    
}