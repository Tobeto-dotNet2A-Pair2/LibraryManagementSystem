using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FavoriteListMaterials;

public interface IFavoriteListMaterialService
{
    Task<FavoriteListMaterial?> GetAsync(
        Expression<Func<FavoriteListMaterial, bool>> predicate,
        Func<IQueryable<FavoriteListMaterial>, IIncludableQueryable<FavoriteListMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FavoriteListMaterial>?> GetListAsync(
        Expression<Func<FavoriteListMaterial, bool>>? predicate = null,
        Func<IQueryable<FavoriteListMaterial>, IOrderedQueryable<FavoriteListMaterial>>? orderBy = null,
        Func<IQueryable<FavoriteListMaterial>, IIncludableQueryable<FavoriteListMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FavoriteListMaterial> AddAsync(FavoriteListMaterial favoriteListMaterial);
    Task<FavoriteListMaterial> UpdateAsync(FavoriteListMaterial favoriteListMaterial);
    Task<FavoriteListMaterial> DeleteAsync(FavoriteListMaterial favoriteListMaterial, bool permanent = false);
}
