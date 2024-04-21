using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MemberNotificationRepository : EfRepositoryBase<MemberNotification, Guid, BaseDbContext>, IMemberNotificationRepository
{
    public MemberNotificationRepository(BaseDbContext context) : base(context)
    {
    }
}