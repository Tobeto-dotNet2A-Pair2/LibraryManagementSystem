using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Authors;

public interface IAuthorService
{
    Task<Author?> GetAsync(
        Expression<Func<Author, bool>> predicate,
        Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Author>?> GetListAsync(
        Expression<Func<Author, bool>>? predicate = null,
        Func<IQueryable<Author>, IOrderedQueryable<Author>>? orderBy = null,
        Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Author> AddAsync(Author author);
    Task<Author> UpdateAsync(Author author);
    Task<Author> DeleteAsync(Author author, bool permanent = false);
}
