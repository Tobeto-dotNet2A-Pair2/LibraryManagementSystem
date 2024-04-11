using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TranslatorMaterials;

public interface ITranslatorMaterialService
{
    Task<TranslatorMaterial?> GetAsync(
        Expression<Func<TranslatorMaterial, bool>> predicate,
        Func<IQueryable<TranslatorMaterial>, IIncludableQueryable<TranslatorMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TranslatorMaterial>?> GetListAsync(
        Expression<Func<TranslatorMaterial, bool>>? predicate = null,
        Func<IQueryable<TranslatorMaterial>, IOrderedQueryable<TranslatorMaterial>>? orderBy = null,
        Func<IQueryable<TranslatorMaterial>, IIncludableQueryable<TranslatorMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TranslatorMaterial> AddAsync(TranslatorMaterial translatorMaterial);
    Task<TranslatorMaterial> UpdateAsync(TranslatorMaterial translatorMaterial);
    Task<TranslatorMaterial> DeleteAsync(TranslatorMaterial translatorMaterial, bool permanent = false);
}
