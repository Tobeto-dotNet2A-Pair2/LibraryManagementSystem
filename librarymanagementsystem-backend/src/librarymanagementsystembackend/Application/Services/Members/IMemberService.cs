using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Members;

public interface IMemberService
{
    Task<Member?> GetAsync(
        Expression<Func<Member, bool>> predicate,
        Func<IQueryable<Member>, IIncludableQueryable<Member, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Member>?> GetListAsync(
        Expression<Func<Member, bool>>? predicate = null,
        Func<IQueryable<Member>, IOrderedQueryable<Member>>? orderBy = null,
        Func<IQueryable<Member>, IIncludableQueryable<Member, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Member> AddAsync(Member member);
    Task<Member> UpdateAsync(Member member);
    Task<Member> DeleteAsync(Member member, bool permanent = false);
}
