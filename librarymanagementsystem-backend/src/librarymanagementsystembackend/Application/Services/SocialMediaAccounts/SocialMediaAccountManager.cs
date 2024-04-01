using Application.Features.SocialMediaAccounts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialMediaAccounts;

public class SocialMediaAccountManager : ISocialMediaAccountService
{
    private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
    private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

    public SocialMediaAccountManager(ISocialMediaAccountRepository socialMediaAccountRepository, SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
    {
        _socialMediaAccountRepository = socialMediaAccountRepository;
        _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
    }

    public async Task<SocialMediaAccount?> GetAsync(
        Expression<Func<SocialMediaAccount, bool>> predicate,
        Func<IQueryable<SocialMediaAccount>, IIncludableQueryable<SocialMediaAccount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return socialMediaAccount;
    }

    public async Task<IPaginate<SocialMediaAccount>?> GetListAsync(
        Expression<Func<SocialMediaAccount, bool>>? predicate = null,
        Func<IQueryable<SocialMediaAccount>, IOrderedQueryable<SocialMediaAccount>>? orderBy = null,
        Func<IQueryable<SocialMediaAccount>, IIncludableQueryable<SocialMediaAccount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SocialMediaAccount> socialMediaAccountList = await _socialMediaAccountRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return socialMediaAccountList;
    }

    public async Task<SocialMediaAccount> AddAsync(SocialMediaAccount socialMediaAccount)
    {
        SocialMediaAccount addedSocialMediaAccount = await _socialMediaAccountRepository.AddAsync(socialMediaAccount);

        return addedSocialMediaAccount;
    }

    public async Task<SocialMediaAccount> UpdateAsync(SocialMediaAccount socialMediaAccount)
    {
        SocialMediaAccount updatedSocialMediaAccount = await _socialMediaAccountRepository.UpdateAsync(socialMediaAccount);

        return updatedSocialMediaAccount;
    }

    public async Task<SocialMediaAccount> DeleteAsync(SocialMediaAccount socialMediaAccount, bool permanent = false)
    {
        SocialMediaAccount deletedSocialMediaAccount = await _socialMediaAccountRepository.DeleteAsync(socialMediaAccount);

        return deletedSocialMediaAccount;
    }
}
