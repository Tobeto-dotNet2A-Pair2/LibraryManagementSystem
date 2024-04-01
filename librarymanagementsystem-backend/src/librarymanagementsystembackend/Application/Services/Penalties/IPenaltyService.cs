using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Penalties;

public interface IPenaltyService
{
    Task<Penalty?> GetAsync(
        Expression<Func<Penalty, bool>> predicate,
        Func<IQueryable<Penalty>, IIncludableQueryable<Penalty, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Penalty>?> GetListAsync(
        Expression<Func<Penalty, bool>>? predicate = null,
        Func<IQueryable<Penalty>, IOrderedQueryable<Penalty>>? orderBy = null,
        Func<IQueryable<Penalty>, IIncludableQueryable<Penalty, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Penalty> AddAsync(Penalty penalty);
    Task<Penalty> UpdateAsync(Penalty penalty);
    Task<Penalty> DeleteAsync(Penalty penalty, bool permanent = false);
}
