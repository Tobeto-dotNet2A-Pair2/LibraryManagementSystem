using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialMediaAccounts;

public interface ISocialMediaAccountService
{
    Task<SocialMediaAccount?> GetAsync(
        Expression<Func<SocialMediaAccount, bool>> predicate,
        Func<IQueryable<SocialMediaAccount>, IIncludableQueryable<SocialMediaAccount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SocialMediaAccount>?> GetListAsync(
        Expression<Func<SocialMediaAccount, bool>>? predicate = null,
        Func<IQueryable<SocialMediaAccount>, IOrderedQueryable<SocialMediaAccount>>? orderBy = null,
        Func<IQueryable<SocialMediaAccount>, IIncludableQueryable<SocialMediaAccount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SocialMediaAccount> AddAsync(SocialMediaAccount socialMediaAccount);
    Task<SocialMediaAccount> UpdateAsync(SocialMediaAccount socialMediaAccount);
    Task<SocialMediaAccount> DeleteAsync(SocialMediaAccount socialMediaAccount, bool permanent = false);
}
