using Application.Features.Notifications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Notifications;

public class NotificationManager : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly NotificationBusinessRules _notificationBusinessRules;

    public NotificationManager(INotificationRepository notificationRepository, NotificationBusinessRules notificationBusinessRules)
    {
        _notificationRepository = notificationRepository;
        _notificationBusinessRules = notificationBusinessRules;
    }

    public async Task<Notification?> GetAsync(
        Expression<Func<Notification, bool>> predicate,
        Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Notification? notification = await _notificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return notification;
    }

    public async Task<IPaginate<Notification>?> GetListAsync(
        Expression<Func<Notification, bool>>? predicate = null,
        Func<IQueryable<Notification>, IOrderedQueryable<Notification>>? orderBy = null,
        Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Notification> notificationList = await _notificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return notificationList;
    }

    public async Task<Notification> AddAsync(Notification notification)
    {
        Notification addedNotification = await _notificationRepository.AddAsync(notification);

        return addedNotification;
    }

    public async Task<Notification> UpdateAsync(Notification notification)
    {
        Notification updatedNotification = await _notificationRepository.UpdateAsync(notification);

        return updatedNotification;
    }

    public async Task<Notification> DeleteAsync(Notification notification, bool permanent = false)
    {
        Notification deletedNotification = await _notificationRepository.DeleteAsync(notification);

        return deletedNotification;
    }
}
