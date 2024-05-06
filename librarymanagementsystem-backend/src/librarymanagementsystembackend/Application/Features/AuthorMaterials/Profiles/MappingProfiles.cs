using Application.Features.AuthorMaterials.Commands.Create;
using Application.Features.AuthorMaterials.Commands.Delete;
using Application.Features.AuthorMaterials.Commands.Update;
using Application.Features.AuthorMaterials.Queries.GetById;
using Application.Features.AuthorMaterials.Queries.GetList;
using Application.Features.BorrowedMaterials.Queries.GetListByMember;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AuthorMaterial, CreateAuthorMaterialCommand>().ReverseMap();
        CreateMap<AuthorMaterial, CreatedAuthorMaterialResponse>().ReverseMap();
        CreateMap<AuthorMaterial, UpdateAuthorMaterialCommand>().ReverseMap();
        CreateMap<AuthorMaterial, UpdatedAuthorMaterialResponse>().ReverseMap();
        CreateMap<AuthorMaterial, DeleteAuthorMaterialCommand>().ReverseMap();
        CreateMap<AuthorMaterial, DeletedAuthorMaterialResponse>().ReverseMap();
        CreateMap<AuthorMaterial, GetByIdAuthorMaterialResponse>().ReverseMap();
        CreateMap<AuthorMaterial, GetListAuthorMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<AuthorMaterial>, GetListResponse<GetListAuthorMaterialListItemDto>>().ReverseMap();

        CreateMap<AuthorMaterial, AuthorMaterialListForBorrowedMaterialDto>()
            .ForMember(a => a.FirstName, opt => opt
                .MapFrom(src => src.Author.FirstName))
            .ForMember(a => a.LastName, opt => opt
                .MapFrom(src => src.Author.LastName));
    }
}