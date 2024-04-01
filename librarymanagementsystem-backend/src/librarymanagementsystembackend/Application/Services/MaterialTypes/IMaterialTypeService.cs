using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialTypes;

public interface IMaterialTypeService
{
    Task<MaterialType?> GetAsync(
        Expression<Func<MaterialType, bool>> predicate,
        Func<IQueryable<MaterialType>, IIncludableQueryable<MaterialType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialType>?> GetListAsync(
        Expression<Func<MaterialType, bool>>? predicate = null,
        Func<IQueryable<MaterialType>, IOrderedQueryable<MaterialType>>? orderBy = null,
        Func<IQueryable<MaterialType>, IIncludableQueryable<MaterialType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialType> AddAsync(MaterialType materialType);
    Task<MaterialType> UpdateAsync(MaterialType materialType);
    Task<MaterialType> DeleteAsync(MaterialType materialType, bool permanent = false);
}
