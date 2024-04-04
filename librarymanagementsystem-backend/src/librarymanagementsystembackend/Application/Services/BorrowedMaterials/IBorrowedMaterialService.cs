using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BorrowedMaterials;

public interface IBorrowedMaterialService
{
    Task<BorrowedMaterial?> GetAsync(
        Expression<Func<BorrowedMaterial, bool>> predicate,
        Func<IQueryable<BorrowedMaterial>, IIncludableQueryable<BorrowedMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BorrowedMaterial>?> GetListAsync(
        Expression<Func<BorrowedMaterial, bool>>? predicate = null,
        Func<IQueryable<BorrowedMaterial>, IOrderedQueryable<BorrowedMaterial>>? orderBy = null,
        Func<IQueryable<BorrowedMaterial>, IIncludableQueryable<BorrowedMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BorrowedMaterial> AddAsync(BorrowedMaterial borrowedMaterial);
    Task<BorrowedMaterial> UpdateAsync(BorrowedMaterial borrowedMaterial);
    Task<BorrowedMaterial> DeleteAsync(BorrowedMaterial borrowedMaterial, bool permanent = false);
}
