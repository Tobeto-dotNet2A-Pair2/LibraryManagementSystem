using Application.Features.MemberNotifications.Constants;
using Application.Features.MemberNotifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MemberNotifications.Constants.MemberNotificationsOperationClaims;

namespace Application.Features.MemberNotifications.Queries.GetById;

public class GetByIdMemberNotificationQuery : IRequest<GetByIdMemberNotificationResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMemberNotificationQueryHandler : IRequestHandler<GetByIdMemberNotificationQuery, GetByIdMemberNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberNotificationRepository _memberNotificationRepository;
        private readonly MemberNotificationBusinessRules _memberNotificationBusinessRules;

        public GetByIdMemberNotificationQueryHandler(IMapper mapper, IMemberNotificationRepository memberNotificationRepository, MemberNotificationBusinessRules memberNotificationBusinessRules)
        {
            _mapper = mapper;
            _memberNotificationRepository = memberNotificationRepository;
            _memberNotificationBusinessRules = memberNotificationBusinessRules;
        }

        public async Task<GetByIdMemberNotificationResponse> Handle(GetByIdMemberNotificationQuery request, CancellationToken cancellationToken)
        {
            MemberNotification? memberNotification = await _memberNotificationRepository.GetAsync(predicate: mn => mn.Id == request.Id, cancellationToken: cancellationToken);
            await _memberNotificationBusinessRules.MemberNotificationShouldExistWhenSelected(memberNotification);

            GetByIdMemberNotificationResponse response = _mapper.Map<GetByIdMemberNotificationResponse>(memberNotification);
            return response;
        }
    }
}