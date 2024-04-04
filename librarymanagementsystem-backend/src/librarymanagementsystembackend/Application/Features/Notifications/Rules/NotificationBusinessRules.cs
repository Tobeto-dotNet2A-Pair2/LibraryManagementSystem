using Application.Features.Notifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Notifications.Rules;

public class NotificationBusinessRules : BaseBusinessRules
{
    private readonly INotificationRepository _notificationRepository;
    private readonly ILocalizationService _localizationService;

    public NotificationBusinessRules(INotificationRepository notificationRepository, ILocalizationService localizationService)
    {
        _notificationRepository = notificationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, NotificationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task NotificationShouldExistWhenSelected(Notification? notification)
    {
        if (notification == null)
            await throwBusinessException(NotificationsBusinessMessages.NotificationNotExists);
    }

    public async Task NotificationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Notification? notification = await _notificationRepository.GetAsync(
            predicate: n => n.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await NotificationShouldExistWhenSelected(notification);
    }
}