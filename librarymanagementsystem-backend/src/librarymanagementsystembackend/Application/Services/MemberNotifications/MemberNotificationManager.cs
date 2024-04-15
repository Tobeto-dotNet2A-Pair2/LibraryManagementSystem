using Application.Features.MemberNotifications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberNotifications;

public class MemberNotificationManager : IMemberNotificationService
{
    private readonly IMemberNotificationRepository _memberNotificationRepository;
    private readonly MemberNotificationBusinessRules _memberNotificationBusinessRules;

    public MemberNotificationManager(IMemberNotificationRepository memberNotificationRepository, MemberNotificationBusinessRules memberNotificationBusinessRules)
    {
        _memberNotificationRepository = memberNotificationRepository;
        _memberNotificationBusinessRules = memberNotificationBusinessRules;
    }

    public async Task<MemberNotification?> GetAsync(
        Expression<Func<MemberNotification, bool>> predicate,
        Func<IQueryable<MemberNotification>, IIncludableQueryable<MemberNotification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MemberNotification? memberNotification = await _memberNotificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return memberNotification;
    }

    public async Task<IPaginate<MemberNotification>?> GetListAsync(
        Expression<Func<MemberNotification, bool>>? predicate = null,
        Func<IQueryable<MemberNotification>, IOrderedQueryable<MemberNotification>>? orderBy = null,
        Func<IQueryable<MemberNotification>, IIncludableQueryable<MemberNotification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MemberNotification> memberNotificationList = await _memberNotificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return memberNotificationList;
    }

    public async Task<MemberNotification> AddAsync(MemberNotification memberNotification)
    {
        MemberNotification addedMemberNotification = await _memberNotificationRepository.AddAsync(memberNotification);

        return addedMemberNotification;
    }

    public async Task<MemberNotification> UpdateAsync(MemberNotification memberNotification)
    {
        MemberNotification updatedMemberNotification = await _memberNotificationRepository.UpdateAsync(memberNotification);

        return updatedMemberNotification;
    }

    public async Task<MemberNotification> DeleteAsync(MemberNotification memberNotification, bool permanent = false)
    {
        MemberNotification deletedMemberNotification = await _memberNotificationRepository.DeleteAsync(memberNotification);

        return deletedMemberNotification;
    }
}
