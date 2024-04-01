using Application.Features.MaterialCopies.Commands.Create;
using Application.Features.MaterialCopies.Commands.Delete;
using Application.Features.MaterialCopies.Commands.Update;
using Application.Features.MaterialCopies.Queries.GetById;
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
    }
}