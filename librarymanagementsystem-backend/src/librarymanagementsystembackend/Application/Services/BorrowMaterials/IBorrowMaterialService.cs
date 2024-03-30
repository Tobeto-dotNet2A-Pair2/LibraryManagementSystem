using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BorrowMaterials;

public interface IBorrowMaterialService
{
    Task<BorrowMaterial?> GetAsync(
        Expression<Func<BorrowMaterial, bool>> predicate,
        Func<IQueryable<BorrowMaterial>, IIncludableQueryable<BorrowMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BorrowMaterial>?> GetListAsync(
        Expression<Func<BorrowMaterial, bool>>? predicate = null,
        Func<IQueryable<BorrowMaterial>, IOrderedQueryable<BorrowMaterial>>? orderBy = null,
        Func<IQueryable<BorrowMaterial>, IIncludableQueryable<BorrowMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BorrowMaterial> AddAsync(BorrowMaterial borrowMaterial);
    Task<BorrowMaterial> UpdateAsync(BorrowMaterial borrowMaterial);
    Task<BorrowMaterial> DeleteAsync(BorrowMaterial borrowMaterial, bool permanent = false);
}
