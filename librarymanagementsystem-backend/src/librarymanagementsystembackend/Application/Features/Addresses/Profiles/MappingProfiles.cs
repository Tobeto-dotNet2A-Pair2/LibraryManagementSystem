using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetById;
using Application.Features.Addresses.Queries.GetList;
using Application.Features.Branches.Commands.Create;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Addresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Address, CreateAddressCommand>()
            .ForMember(a => a.District.Id, opt =>
                opt.MapFrom(src => src.Street.Neighborhood.District.Id));
        CreateMap<Address, CreatedAddressResponse>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        CreateMap<Address, UpdatedAddressResponse>().ReverseMap();
        CreateMap<Address, DeleteAddressCommand>().ReverseMap();
        CreateMap<Address, DeletedAddressResponse>().ReverseMap();
        CreateMap<Address, GetByIdAddressResponse>().ReverseMap();
        CreateMap<Address, GetListAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<Address>, GetListResponse<GetListAddressListItemDto>>().ReverseMap();

        //Örnek
        CreateMap<AddressDto, Address>()
            .ForMember(a => a.Name, src => src.MapFrom(a => a.Line))
            .ForMember(a => a.Description, src => src.MapFrom(a => a.Line2));
    }
}