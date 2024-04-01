using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Libraries;

public interface ILibraryService
{
    Task<Library?> GetAsync(
        Expression<Func<Library, bool>> predicate,
        Func<IQueryable<Library>, IIncludableQueryable<Library, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Library>?> GetListAsync(
        Expression<Func<Library, bool>>? predicate = null,
        Func<IQueryable<Library>, IOrderedQueryable<Library>>? orderBy = null,
        Func<IQueryable<Library>, IIncludableQueryable<Library, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Library> AddAsync(Library library);
    Task<Library> UpdateAsync(Library library);
    Task<Library> DeleteAsync(Library library, bool permanent = false);
}
