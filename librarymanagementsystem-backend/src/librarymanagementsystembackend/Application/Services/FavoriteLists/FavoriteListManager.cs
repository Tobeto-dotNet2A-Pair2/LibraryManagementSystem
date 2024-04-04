using Application.Features.FavoriteLists.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FavoriteLists;

public class FavoriteListManager : IFavoriteListService
{
    private readonly IFavoriteListRepository _favoriteListRepository;
    private readonly FavoriteListBusinessRules _favoriteListBusinessRules;

    public FavoriteListManager(IFavoriteListRepository favoriteListRepository, FavoriteListBusinessRules favoriteListBusinessRules)
    {
        _favoriteListRepository = favoriteListRepository;
        _favoriteListBusinessRules = favoriteListBusinessRules;
    }

    public async Task<FavoriteList?> GetAsync(
        Expression<Func<FavoriteList, bool>> predicate,
        Func<IQueryable<FavoriteList>, IIncludableQueryable<FavoriteList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FavoriteList? favoriteList = await _favoriteListRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return favoriteList;
    }

    public async Task<IPaginate<FavoriteList>?> GetListAsync(
        Expression<Func<FavoriteList, bool>>? predicate = null,
        Func<IQueryable<FavoriteList>, IOrderedQueryable<FavoriteList>>? orderBy = null,
        Func<IQueryable<FavoriteList>, IIncludableQueryable<FavoriteList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FavoriteList> favoriteListList = await _favoriteListRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return favoriteListList;
    }

    public async Task<FavoriteList> AddAsync(FavoriteList favoriteList)
    {
        FavoriteList addedFavoriteList = await _favoriteListRepository.AddAsync(favoriteList);

        return addedFavoriteList;
    }

    public async Task<FavoriteList> UpdateAsync(FavoriteList favoriteList)
    {
        FavoriteList updatedFavoriteList = await _favoriteListRepository.UpdateAsync(favoriteList);

        return updatedFavoriteList;
    }

    public async Task<FavoriteList> DeleteAsync(FavoriteList favoriteList, bool permanent = false)
    {
        FavoriteList deletedFavoriteList = await _favoriteListRepository.DeleteAsync(favoriteList);

        return deletedFavoriteList;
    }
}
