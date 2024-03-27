using Application.Features.Branches.Commands.Create;
using Application.Features.Branches.Commands.Delete;
using Application.Features.Branches.Commands.Update;
using Application.Features.Branches.Queries.GetById;
using Application.Features.Branches.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Branches.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Branch, CreateBranchCommand>().ReverseMap();
        CreateMap<Branch, CreatedBranchResponse>().ReverseMap();
        CreateMap<Branch, UpdateBranchCommand>().ReverseMap();
        CreateMap<Branch, UpdatedBranchResponse>().ReverseMap();
        CreateMap<Branch, DeleteBranchCommand>().ReverseMap();
        CreateMap<Branch, DeletedBranchResponse>().ReverseMap();
        CreateMap<Branch, GetByIdBranchResponse>().ReverseMap();
        CreateMap<Branch, GetListBranchListItemDto>().ReverseMap();
        CreateMap<IPaginate<Branch>, GetListResponse<GetListBranchListItemDto>>().ReverseMap();
    }
}