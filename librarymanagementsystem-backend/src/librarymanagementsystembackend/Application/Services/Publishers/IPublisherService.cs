using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Publishers;

public interface IPublisherService
{
    Task<Publisher?> GetAsync(
        Expression<Func<Publisher, bool>> predicate,
        Func<IQueryable<Publisher>, IIncludableQueryable<Publisher, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Publisher>?> GetListAsync(
        Expression<Func<Publisher, bool>>? predicate = null,
        Func<IQueryable<Publisher>, IOrderedQueryable<Publisher>>? orderBy = null,
        Func<IQueryable<Publisher>, IIncludableQueryable<Publisher, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Publisher> AddAsync(Publisher publisher);
    Task<Publisher> UpdateAsync(Publisher publisher);
    Task<Publisher> DeleteAsync(Publisher publisher, bool permanent = false);
}
