using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorMaterials;

public interface IAuthorMaterialService
{
    Task<AuthorMaterial?> GetAsync(
        Expression<Func<AuthorMaterial, bool>> predicate,
        Func<IQueryable<AuthorMaterial>, IIncludableQueryable<AuthorMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorMaterial>?> GetListAsync(
        Expression<Func<AuthorMaterial, bool>>? predicate = null,
        Func<IQueryable<AuthorMaterial>, IOrderedQueryable<AuthorMaterial>>? orderBy = null,
        Func<IQueryable<AuthorMaterial>, IIncludableQueryable<AuthorMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorMaterial> AddAsync(AuthorMaterial authorMaterial);
    Task<AuthorMaterial> UpdateAsync(AuthorMaterial authorMaterial);
    Task<AuthorMaterial> DeleteAsync(AuthorMaterial authorMaterial, bool permanent = false);
}
