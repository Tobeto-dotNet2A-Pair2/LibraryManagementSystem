using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class NotificationRepository : EfRepositoryBase<Notification, Guid, BaseDbContext>, INotificationRepository
{
    public NotificationRepository(BaseDbContext context) : base(context)
    {
    }
}