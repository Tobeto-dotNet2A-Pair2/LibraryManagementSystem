using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FavoriteLists;

public interface IFavoriteListService
{
    Task<FavoriteList?> GetAsync(
        Expression<Func<FavoriteList, bool>> predicate,
        Func<IQueryable<FavoriteList>, IIncludableQueryable<FavoriteList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FavoriteList>?> GetListAsync(
        Expression<Func<FavoriteList, bool>>? predicate = null,
        Func<IQueryable<FavoriteList>, IOrderedQueryable<FavoriteList>>? orderBy = null,
        Func<IQueryable<FavoriteList>, IIncludableQueryable<FavoriteList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FavoriteList> AddAsync(FavoriteList favoriteList);
    Task<FavoriteList> UpdateAsync(FavoriteList favoriteList);
    Task<FavoriteList> DeleteAsync(FavoriteList favoriteList, bool permanent = false);
}
