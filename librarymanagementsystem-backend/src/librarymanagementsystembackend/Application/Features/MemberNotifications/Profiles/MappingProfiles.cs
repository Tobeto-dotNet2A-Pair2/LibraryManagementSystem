using Application.Features.MemberNotifications.Commands.Create;
using Application.Features.MemberNotifications.Commands.Delete;
using Application.Features.MemberNotifications.Commands.Update;
using Application.Features.MemberNotifications.Queries.GetById;
using Application.Features.MemberNotifications.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MemberNotifications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MemberNotification, CreateMemberNotificationCommand>().ReverseMap();
        CreateMap<MemberNotification, CreatedMemberNotificationResponse>().ReverseMap();
        CreateMap<MemberNotification, UpdateMemberNotificationCommand>().ReverseMap();
        CreateMap<MemberNotification, UpdatedMemberNotificationResponse>().ReverseMap();
        CreateMap<MemberNotification, DeleteMemberNotificationCommand>().ReverseMap();
        CreateMap<MemberNotification, DeletedMemberNotificationResponse>().ReverseMap();
        CreateMap<MemberNotification, GetByIdMemberNotificationResponse>().ReverseMap();
        CreateMap<MemberNotification, GetListMemberNotificationListItemDto>().ReverseMap();
        CreateMap<IPaginate<MemberNotification>, GetListResponse<GetListMemberNotificationListItemDto>>().ReverseMap();
    }
}