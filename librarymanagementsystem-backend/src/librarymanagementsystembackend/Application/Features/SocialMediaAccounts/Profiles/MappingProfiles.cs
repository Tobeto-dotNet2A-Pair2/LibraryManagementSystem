using Application.Features.SocialMediaAccounts.Commands.Create;
using Application.Features.SocialMediaAccounts.Commands.Delete;
using Application.Features.SocialMediaAccounts.Commands.Update;
using Application.Features.SocialMediaAccounts.Queries.GetById;
using Application.Features.SocialMediaAccounts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SocialMediaAccounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SocialMediaAccount, CreateSocialMediaAccountCommand>().ReverseMap();
        CreateMap<SocialMediaAccount, CreatedSocialMediaAccountResponse>().ReverseMap();
        CreateMap<SocialMediaAccount, UpdateSocialMediaAccountCommand>().ReverseMap();
        CreateMap<SocialMediaAccount, UpdatedSocialMediaAccountResponse>().ReverseMap();
        CreateMap<SocialMediaAccount, DeleteSocialMediaAccountCommand>().ReverseMap();
        CreateMap<SocialMediaAccount, DeletedSocialMediaAccountResponse>().ReverseMap();
        CreateMap<SocialMediaAccount, GetByIdSocialMediaAccountResponse>().ReverseMap();
        CreateMap<SocialMediaAccount, GetListSocialMediaAccountListItemDto>().ReverseMap();
        CreateMap<IPaginate<SocialMediaAccount>, GetListResponse<GetListSocialMediaAccountListItemDto>>().ReverseMap();
    }
}