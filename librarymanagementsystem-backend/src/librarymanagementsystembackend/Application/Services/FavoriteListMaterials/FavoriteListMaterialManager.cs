using Application.Features.FavoriteListMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FavoriteListMaterials;

public class FavoriteListMaterialManager : IFavoriteListMaterialService
{
    private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
    private readonly FavoriteListMaterialBusinessRules _favoriteListMaterialBusinessRules;

    public FavoriteListMaterialManager(IFavoriteListMaterialRepository favoriteListMaterialRepository, FavoriteListMaterialBusinessRules favoriteListMaterialBusinessRules)
    {
        _favoriteListMaterialRepository = favoriteListMaterialRepository;
        _favoriteListMaterialBusinessRules = favoriteListMaterialBusinessRules;
    }

    public async Task<FavoriteListMaterial?> GetAsync(
        Expression<Func<FavoriteListMaterial, bool>> predicate,
        Func<IQueryable<FavoriteListMaterial>, IIncludableQueryable<FavoriteListMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FavoriteListMaterial? favoriteListMaterial = await _favoriteListMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return favoriteListMaterial;
    }

    public async Task<IPaginate<FavoriteListMaterial>?> GetListAsync(
        Expression<Func<FavoriteListMaterial, bool>>? predicate = null,
        Func<IQueryable<FavoriteListMaterial>, IOrderedQueryable<FavoriteListMaterial>>? orderBy = null,
        Func<IQueryable<FavoriteListMaterial>, IIncludableQueryable<FavoriteListMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FavoriteListMaterial> favoriteListMaterialList = await _favoriteListMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return favoriteListMaterialList;
    }

    public async Task<FavoriteListMaterial> AddAsync(FavoriteListMaterial favoriteListMaterial)
    {
        FavoriteListMaterial addedFavoriteListMaterial = await _favoriteListMaterialRepository.AddAsync(favoriteListMaterial);

        return addedFavoriteListMaterial;
    }

    public async Task<FavoriteListMaterial> UpdateAsync(FavoriteListMaterial favoriteListMaterial)
    {
        FavoriteListMaterial updatedFavoriteListMaterial = await _favoriteListMaterialRepository.UpdateAsync(favoriteListMaterial);

        return updatedFavoriteListMaterial;
    }

    public async Task<FavoriteListMaterial> DeleteAsync(FavoriteListMaterial favoriteListMaterial, bool permanent = false)
    {
        FavoriteListMaterial deletedFavoriteListMaterial = await _favoriteListMaterialRepository.DeleteAsync(favoriteListMaterial);

        return deletedFavoriteListMaterial;
    }
}
