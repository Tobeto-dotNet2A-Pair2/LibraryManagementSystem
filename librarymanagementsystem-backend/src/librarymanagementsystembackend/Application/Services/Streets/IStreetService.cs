using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Streets;

public interface IStreetService
{
    Task<Street?> GetAsync(
        Expression<Func<Street, bool>> predicate,
        Func<IQueryable<Street>, IIncludableQueryable<Street, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Street>?> GetListAsync(
        Expression<Func<Street, bool>>? predicate = null,
        Func<IQueryable<Street>, IOrderedQueryable<Street>>? orderBy = null,
        Func<IQueryable<Street>, IIncludableQueryable<Street, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Street> AddAsync(Street street);
    Task<Street> UpdateAsync(Street street);
    Task<Street> DeleteAsync(Street street, bool permanent = false);
}
