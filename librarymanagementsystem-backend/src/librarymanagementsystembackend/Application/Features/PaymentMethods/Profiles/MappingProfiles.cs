using Application.Features.PaymentMethods.Commands.Create;
using Application.Features.PaymentMethods.Commands.Delete;
using Application.Features.PaymentMethods.Commands.Update;
using Application.Features.PaymentMethods.Queries.GetById;
using Application.Features.PaymentMethods.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PaymentMethods.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PaymentMethod, CreatePaymentMethodCommand>().ReverseMap();
        CreateMap<PaymentMethod, CreatedPaymentMethodResponse>().ReverseMap();
        CreateMap<PaymentMethod, UpdatePaymentMethodCommand>().ReverseMap();
        CreateMap<PaymentMethod, UpdatedPaymentMethodResponse>().ReverseMap();
        CreateMap<PaymentMethod, DeletePaymentMethodCommand>().ReverseMap();
        CreateMap<PaymentMethod, DeletedPaymentMethodResponse>().ReverseMap();
        CreateMap<PaymentMethod, GetByIdPaymentMethodResponse>().ReverseMap();
        CreateMap<PaymentMethod, GetListPaymentMethodListItemDto>().ReverseMap();
        CreateMap<IPaginate<PaymentMethod>, GetListResponse<GetListPaymentMethodListItemDto>>().ReverseMap();
    }
}