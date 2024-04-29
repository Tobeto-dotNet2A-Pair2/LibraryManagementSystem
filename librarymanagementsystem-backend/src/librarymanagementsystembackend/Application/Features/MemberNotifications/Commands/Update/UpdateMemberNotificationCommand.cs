using Application.Features.MemberNotifications.Constants;
using Application.Features.MemberNotifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MemberNotifications.Constants.MemberNotificationsOperationClaims;

namespace Application.Features.MemberNotifications.Commands.Update;

public class UpdateMemberNotificationCommand : IRequest<UpdatedMemberNotificationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }

    public string[] Roles => [Admin, Write, MemberNotificationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberNotifications"];

    public class UpdateMemberNotificationCommandHandler : IRequestHandler<UpdateMemberNotificationCommand, UpdatedMemberNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberNotificationRepository _memberNotificationRepository;
        private readonly MemberNotificationBusinessRules _memberNotificationBusinessRules;

        public UpdateMemberNotificationCommandHandler(IMapper mapper, IMemberNotificationRepository memberNotificationRepository,
                                         MemberNotificationBusinessRules memberNotificationBusinessRules)
        {
            _mapper = mapper;
            _memberNotificationRepository = memberNotificationRepository;
            _memberNotificationBusinessRules = memberNotificationBusinessRules;
        }

        public async Task<UpdatedMemberNotificationResponse> Handle(UpdateMemberNotificationCommand request, CancellationToken cancellationToken)
        {
            MemberNotification? memberNotification = await _memberNotificationRepository.GetAsync(predicate: mn => mn.Id == request.Id, cancellationToken: cancellationToken);
            await _memberNotificationBusinessRules.MemberNotificationShouldExistWhenSelected(memberNotification);
            memberNotification = _mapper.Map(request, memberNotification);

            await _memberNotificationRepository.UpdateAsync(memberNotification!);

            UpdatedMemberNotificationResponse response = _mapper.Map<UpdatedMemberNotificationResponse>(memberNotification);
            return response;
        }
    }
}