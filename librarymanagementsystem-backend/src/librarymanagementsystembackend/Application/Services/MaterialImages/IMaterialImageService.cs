using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialImages;

public interface IMaterialImageService
{
    Task<MaterialImage?> GetAsync(
        Expression<Func<MaterialImage, bool>> predicate,
        Func<IQueryable<MaterialImage>, IIncludableQueryable<MaterialImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialImage>?> GetListAsync(
        Expression<Func<MaterialImage, bool>>? predicate = null,
        Func<IQueryable<MaterialImage>, IOrderedQueryable<MaterialImage>>? orderBy = null,
        Func<IQueryable<MaterialImage>, IIncludableQueryable<MaterialImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialImage> AddAsync(MaterialImage materialImage);
    Task<MaterialImage> UpdateAsync(MaterialImage materialImage);
    Task<MaterialImage> DeleteAsync(MaterialImage materialImage, bool permanent = false);
}
