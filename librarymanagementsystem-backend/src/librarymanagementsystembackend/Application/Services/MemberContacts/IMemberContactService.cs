using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberContacts;

public interface IMemberContactService
{
    Task<MemberContact?> GetAsync(
        Expression<Func<MemberContact, bool>> predicate,
        Func<IQueryable<MemberContact>, IIncludableQueryable<MemberContact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MemberContact>?> GetListAsync(
        Expression<Func<MemberContact, bool>>? predicate = null,
        Func<IQueryable<MemberContact>, IOrderedQueryable<MemberContact>>? orderBy = null,
        Func<IQueryable<MemberContact>, IIncludableQueryable<MemberContact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MemberContact> AddAsync(MemberContact memberContact);
    Task<MemberContact> UpdateAsync(MemberContact memberContact);
    Task<MemberContact> DeleteAsync(MemberContact memberContact, bool permanent = false);
}
