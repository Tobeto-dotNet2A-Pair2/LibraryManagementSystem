using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Neighborhoods;

public interface INeighborhoodService
{
    Task<Neighborhood?> GetAsync(
        Expression<Func<Neighborhood, bool>> predicate,
        Func<IQueryable<Neighborhood>, IIncludableQueryable<Neighborhood, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Neighborhood>?> GetListAsync(
        Expression<Func<Neighborhood, bool>>? predicate = null,
        Func<IQueryable<Neighborhood>, IOrderedQueryable<Neighborhood>>? orderBy = null,
        Func<IQueryable<Neighborhood>, IIncludableQueryable<Neighborhood, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Neighborhood> AddAsync(Neighborhood neighborhood);
    Task<Neighborhood> UpdateAsync(Neighborhood neighborhood);
    Task<Neighborhood> DeleteAsync(Neighborhood neighborhood, bool permanent = false);
}
