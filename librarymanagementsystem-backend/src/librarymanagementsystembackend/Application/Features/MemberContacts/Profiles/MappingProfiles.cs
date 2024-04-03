using Application.Features.MemberContacts.Commands.Create;
using Application.Features.MemberContacts.Commands.Delete;
using Application.Features.MemberContacts.Commands.Update;
using Application.Features.MemberContacts.Queries.GetById;
using Application.Features.MemberContacts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MemberContacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MemberContact, CreateMemberContactCommand>().ReverseMap();
        CreateMap<MemberContact, CreatedMemberContactResponse>().ReverseMap();
        CreateMap<MemberContact, UpdateMemberContactCommand>().ReverseMap();
        CreateMap<MemberContact, UpdatedMemberContactResponse>().ReverseMap();
        CreateMap<MemberContact, DeleteMemberContactCommand>().ReverseMap();
        CreateMap<MemberContact, DeletedMemberContactResponse>().ReverseMap();
        CreateMap<MemberContact, GetByIdMemberContactResponse>().ReverseMap();
        CreateMap<MemberContact, GetListMemberContactListItemDto>().ReverseMap();
        CreateMap<IPaginate<MemberContact>, GetListResponse<GetListMemberContactListItemDto>>().ReverseMap();
    }
}