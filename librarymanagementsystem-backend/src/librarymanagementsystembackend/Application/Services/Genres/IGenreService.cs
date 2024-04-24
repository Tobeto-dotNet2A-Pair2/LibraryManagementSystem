using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Genres;

public interface IGenreService
{
    Task<Genre?> GetAsync(
        Expression<Func<Genre, bool>> predicate,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Genre>?> GetListAsync(
        Expression<Func<Genre, bool>>? predicate = null,
        Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Genre> AddAsync(Genre genre);
    Task<Genre> UpdateAsync(Genre genre);
    Task<Genre> DeleteAsync(Genre genre, bool permanent = false);
}
