using Application.Features.MemberNotifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MemberNotifications.Rules;

public class MemberNotificationBusinessRules : BaseBusinessRules
{
    private readonly IMemberNotificationRepository _memberNotificationRepository;
    private readonly ILocalizationService _localizationService;

    public MemberNotificationBusinessRules(IMemberNotificationRepository memberNotificationRepository, ILocalizationService localizationService)
    {
        _memberNotificationRepository = memberNotificationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MemberNotificationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MemberNotificationShouldExistWhenSelected(MemberNotification? memberNotification)
    {
        if (memberNotification == null)
            await throwBusinessException(MemberNotificationsBusinessMessages.MemberNotificationNotExists);
    }

    public async Task MemberNotificationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MemberNotification? memberNotification = await _memberNotificationRepository.GetAsync(
            predicate: mn => mn.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MemberNotificationShouldExistWhenSelected(memberNotification);
    }
}