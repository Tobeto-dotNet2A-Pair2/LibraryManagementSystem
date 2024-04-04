using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Locations;

public interface ILocationService
{
    Task<Location?> GetAsync(
        Expression<Func<Location, bool>> predicate,
        Func<IQueryable<Location>, IIncludableQueryable<Location, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Location>?> GetListAsync(
        Expression<Func<Location, bool>>? predicate = null,
        Func<IQueryable<Location>, IOrderedQueryable<Location>>? orderBy = null,
        Func<IQueryable<Location>, IIncludableQueryable<Location, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Location> AddAsync(Location location);
    Task<Location> UpdateAsync(Location location);
    Task<Location> DeleteAsync(Location location, bool permanent = false);
}
