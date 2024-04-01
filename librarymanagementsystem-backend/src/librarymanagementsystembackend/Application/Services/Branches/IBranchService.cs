using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Branches;

public interface IBranchService
{
    Task<Branch?> GetAsync(
        Expression<Func<Branch, bool>> predicate,
        Func<IQueryable<Branch>, IIncludableQueryable<Branch, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Branch>?> GetListAsync(
        Expression<Func<Branch, bool>>? predicate = null,
        Func<IQueryable<Branch>, IOrderedQueryable<Branch>>? orderBy = null,
        Func<IQueryable<Branch>, IIncludableQueryable<Branch, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Branch> AddAsync(Branch branch);
    Task<Branch> UpdateAsync(Branch branch);
    Task<Branch> DeleteAsync(Branch branch, bool permanent = false);
}
