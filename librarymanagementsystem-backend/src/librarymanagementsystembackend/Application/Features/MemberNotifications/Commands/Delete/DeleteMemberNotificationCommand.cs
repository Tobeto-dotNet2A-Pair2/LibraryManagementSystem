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

namespace Application.Features.MemberNotifications.Commands.Delete;

public class DeleteMemberNotificationCommand : IRequest<DeletedMemberNotificationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MemberNotificationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberNotifications"];

    public class DeleteMemberNotificationCommandHandler : IRequestHandler<DeleteMemberNotificationCommand, DeletedMemberNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberNotificationRepository _memberNotificationRepository;
        private readonly MemberNotificationBusinessRules _memberNotificationBusinessRules;

        public DeleteMemberNotificationCommandHandler(IMapper mapper, IMemberNotificationRepository memberNotificationRepository,
                                         MemberNotificationBusinessRules memberNotificationBusinessRules)
        {
            _mapper = mapper;
            _memberNotificationRepository = memberNotificationRepository;
            _memberNotificationBusinessRules = memberNotificationBusinessRules;
        }

        public async Task<DeletedMemberNotificationResponse> Handle(DeleteMemberNotificationCommand request, CancellationToken cancellationToken)
        {
            MemberNotification? memberNotification = await _memberNotificationRepository.GetAsync(predicate: mn => mn.Id == request.Id, cancellationToken: cancellationToken);
            await _memberNotificationBusinessRules.MemberNotificationShouldExistWhenSelected(memberNotification);

            await _memberNotificationRepository.DeleteAsync(memberNotification!);

            DeletedMemberNotificationResponse response = _mapper.Map<DeletedMemberNotificationResponse>(memberNotification);
            return response;
        }
    }
}