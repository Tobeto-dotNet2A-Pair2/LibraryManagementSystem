using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialGenres;

public interface IMaterialGenreService
{
    Task<MaterialGenre?> GetAsync(
        Expression<Func<MaterialGenre, bool>> predicate,
        Func<IQueryable<MaterialGenre>, IIncludableQueryable<MaterialGenre, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialGenre>?> GetListAsync(
        Expression<Func<MaterialGenre, bool>>? predicate = null,
        Func<IQueryable<MaterialGenre>, IOrderedQueryable<MaterialGenre>>? orderBy = null,
        Func<IQueryable<MaterialGenre>, IIncludableQueryable<MaterialGenre, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialGenre> AddAsync(MaterialGenre materialGenre);
    Task<MaterialGenre> UpdateAsync(MaterialGenre materialGenre);
    Task<MaterialGenre> DeleteAsync(MaterialGenre materialGenre, bool permanent = false);
}
