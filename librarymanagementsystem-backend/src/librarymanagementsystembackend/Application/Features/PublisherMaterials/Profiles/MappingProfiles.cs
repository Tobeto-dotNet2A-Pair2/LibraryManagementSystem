using Application.Features.PublisherMaterials.Commands.Create;
using Application.Features.PublisherMaterials.Commands.Delete;
using Application.Features.PublisherMaterials.Commands.Update;
using Application.Features.PublisherMaterials.Queries.GetById;
using Application.Features.PublisherMaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PublisherMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PublisherMaterial, CreatePublisherMaterialCommand>().ReverseMap();
        CreateMap<PublisherMaterial, CreatedPublisherMaterialResponse>().ReverseMap();
        CreateMap<PublisherMaterial, UpdatePublisherMaterialCommand>().ReverseMap();
        CreateMap<PublisherMaterial, UpdatedPublisherMaterialResponse>().ReverseMap();
        CreateMap<PublisherMaterial, DeletePublisherMaterialCommand>().ReverseMap();
        CreateMap<PublisherMaterial, DeletedPublisherMaterialResponse>().ReverseMap();
        CreateMap<PublisherMaterial, GetByIdPublisherMaterialResponse>().ReverseMap();
        CreateMap<PublisherMaterial, GetListPublisherMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<PublisherMaterial>, GetListResponse<GetListPublisherMaterialListItemDto>>().ReverseMap();
    }
}