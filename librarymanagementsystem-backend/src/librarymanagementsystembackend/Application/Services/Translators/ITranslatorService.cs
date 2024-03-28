using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Translators;

public interface ITranslatorService
{
    Task<Translator?> GetAsync(
        Expression<Func<Translator, bool>> predicate,
        Func<IQueryable<Translator>, IIncludableQueryable<Translator, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Translator>?> GetListAsync(
        Expression<Func<Translator, bool>>? predicate = null,
        Func<IQueryable<Translator>, IOrderedQueryable<Translator>>? orderBy = null,
        Func<IQueryable<Translator>, IIncludableQueryable<Translator, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Translator> AddAsync(Translator translator);
    Task<Translator> UpdateAsync(Translator translator);
    Task<Translator> DeleteAsync(Translator translator, bool permanent = false);
}
