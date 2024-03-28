using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Materials;

public interface IMaterialService
{
    Task<Material?> GetAsync(
        Expression<Func<Material, bool>> predicate,
        Func<IQueryable<Material>, IIncludableQueryable<Material, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Material>?> GetListAsync(
        Expression<Func<Material, bool>>? predicate = null,
        Func<IQueryable<Material>, IOrderedQueryable<Material>>? orderBy = null,
        Func<IQueryable<Material>, IIncludableQueryable<Material, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Material> AddAsync(Material material);
    Task<Material> UpdateAsync(Material material);
    Task<Material> DeleteAsync(Material material, bool permanent = false);
}
