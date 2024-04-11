using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LanguageMaterials;

public interface ILanguageMaterialService
{
    Task<LanguageMaterial?> GetAsync(
        Expression<Func<LanguageMaterial, bool>> predicate,
        Func<IQueryable<LanguageMaterial>, IIncludableQueryable<LanguageMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LanguageMaterial>?> GetListAsync(
        Expression<Func<LanguageMaterial, bool>>? predicate = null,
        Func<IQueryable<LanguageMaterial>, IOrderedQueryable<LanguageMaterial>>? orderBy = null,
        Func<IQueryable<LanguageMaterial>, IIncludableQueryable<LanguageMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LanguageMaterial> AddAsync(LanguageMaterial languageMaterial);
    Task<LanguageMaterial> UpdateAsync(LanguageMaterial languageMaterial);
    Task<LanguageMaterial> DeleteAsync(LanguageMaterial languageMaterial, bool permanent = false);
}
