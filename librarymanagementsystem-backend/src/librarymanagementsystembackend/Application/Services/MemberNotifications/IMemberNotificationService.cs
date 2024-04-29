using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberNotifications;

public interface IMemberNotificationService
{
    Task<MemberNotification?> GetAsync(
        Expression<Func<MemberNotification, bool>> predicate,
        Func<IQueryable<MemberNotification>, IIncludableQueryable<MemberNotification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MemberNotification>?> GetListAsync(
        Expression<Func<MemberNotification, bool>>? predicate = null,
        Func<IQueryable<MemberNotification>, IOrderedQueryable<MemberNotification>>? orderBy = null,
        Func<IQueryable<MemberNotification>, IIncludableQueryable<MemberNotification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MemberNotification> AddAsync(MemberNotification memberNotification);
    Task<MemberNotification> UpdateAsync(MemberNotification memberNotification);
    Task<MemberNotification> DeleteAsync(MemberNotification memberNotification, bool permanent = false);
}
