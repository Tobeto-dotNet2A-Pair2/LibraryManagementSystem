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

namespace Application.Features.MemberNotifications.Commands.Create;

public class CreateMemberNotificationCommand : IRequest<CreatedMemberNotificationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid MemberId { get; set; }
    public Guid NotificationId { get; set; }

    public string[] Roles => [Admin, Write, MemberNotificationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberNotifications"];

    public class CreateMemberNotificationCommandHandler : IRequestHandler<CreateMemberNotificationCommand, CreatedMemberNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberNotificationRepository _memberNotificationRepository;
        private readonly MemberNotificationBusinessRules _memberNotificationBusinessRules;

        public CreateMemberNotificationCommandHandler(IMapper mapper, IMemberNotificationRepository memberNotificationRepository,
                                         MemberNotificationBusinessRules memberNotificationBusinessRules)
        {
            _mapper = mapper;
            _memberNotificationRepository = memberNotificationRepository;
            _memberNotificationBusinessRules = memberNotificationBusinessRules;
        }

        public async Task<CreatedMemberNotificationResponse> Handle(CreateMemberNotificationCommand request, CancellationToken cancellationToken)
        {
            MemberNotification memberNotification = _mapper.Map<MemberNotification>(request);

            await _memberNotificationRepository.AddAsync(memberNotification);

            CreatedMemberNotificationResponse response = _mapper.Map<CreatedMemberNotificationResponse>(memberNotification);
            return response;
        }
    }
}