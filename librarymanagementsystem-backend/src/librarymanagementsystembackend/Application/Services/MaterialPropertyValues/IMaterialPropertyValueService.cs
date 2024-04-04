using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialPropertyValues;

public interface IMaterialPropertyValueService
{
    Task<MaterialPropertyValue?> GetAsync(
        Expression<Func<MaterialPropertyValue, bool>> predicate,
        Func<IQueryable<MaterialPropertyValue>, IIncludableQueryable<MaterialPropertyValue, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialPropertyValue>?> GetListAsync(
        Expression<Func<MaterialPropertyValue, bool>>? predicate = null,
        Func<IQueryable<MaterialPropertyValue>, IOrderedQueryable<MaterialPropertyValue>>? orderBy = null,
        Func<IQueryable<MaterialPropertyValue>, IIncludableQueryable<MaterialPropertyValue, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialPropertyValue> AddAsync(MaterialPropertyValue materialPropertyValue);
    Task<MaterialPropertyValue> UpdateAsync(MaterialPropertyValue materialPropertyValue);
    Task<MaterialPropertyValue> DeleteAsync(MaterialPropertyValue materialPropertyValue, bool permanent = false);
}
