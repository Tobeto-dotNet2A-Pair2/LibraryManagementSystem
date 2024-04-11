using Application.Features.MemberAddresses.Commands.Create;
using Application.Features.MemberAddresses.Commands.Delete;
using Application.Features.MemberAddresses.Commands.Update;
using Application.Features.MemberAddresses.Queries.GetById;
using Application.Features.MemberAddresses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MemberAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MemberAddress, CreateMemberAddressCommand>().ReverseMap();
        CreateMap<MemberAddress, CreatedMemberAddressResponse>().ReverseMap();
        CreateMap<MemberAddress, UpdateMemberAddressCommand>().ReverseMap();
        CreateMap<MemberAddress, UpdatedMemberAddressResponse>().ReverseMap();
        CreateMap<MemberAddress, DeleteMemberAddressCommand>().ReverseMap();
        CreateMap<MemberAddress, DeletedMemberAddressResponse>().ReverseMap();
        CreateMap<MemberAddress, GetByIdMemberAddressResponse>().ReverseMap();
        CreateMap<MemberAddress, GetListMemberAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<MemberAddress>, GetListResponse<GetListMemberAddressListItemDto>>().ReverseMap();
    }
}