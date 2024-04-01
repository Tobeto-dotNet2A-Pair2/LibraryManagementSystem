using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialProperties;

public interface IMaterialPropertyService
{
    Task<MaterialProperty?> GetAsync(
        Expression<Func<MaterialProperty, bool>> predicate,
        Func<IQueryable<MaterialProperty>, IIncludableQueryable<MaterialProperty, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialProperty>?> GetListAsync(
        Expression<Func<MaterialProperty, bool>>? predicate = null,
        Func<IQueryable<MaterialProperty>, IOrderedQueryable<MaterialProperty>>? orderBy = null,
        Func<IQueryable<MaterialProperty>, IIncludableQueryable<MaterialProperty, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialProperty> AddAsync(MaterialProperty materialProperty);
    Task<MaterialProperty> UpdateAsync(MaterialProperty materialProperty);
    Task<MaterialProperty> DeleteAsync(MaterialProperty materialProperty, bool permanent = false);
}
