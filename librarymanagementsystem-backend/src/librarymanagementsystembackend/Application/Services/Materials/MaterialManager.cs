using Application.Features.Materials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Materials;

public class MaterialManager : IMaterialService
{
    private readonly IMaterialRepository _materialRepository;
    private readonly MaterialBusinessRules _materialBusinessRules;

    public MaterialManager(IMaterialRepository materialRepository, MaterialBusinessRules materialBusinessRules)
    {
        _materialRepository = materialRepository;
        _materialBusinessRules = materialBusinessRules;
    }

    public async Task<Material?> GetAsync(
        Expression<Func<Material, bool>> predicate,
        Func<IQueryable<Material>, IIncludableQueryable<Material, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Material? material = await _materialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return material;
    }

    public async Task<IPaginate<Material>?> GetListAsync(
        Expression<Func<Material, bool>>? predicate = null,
        Func<IQueryable<Material>, IOrderedQueryable<Material>>? orderBy = null,
        Func<IQueryable<Material>, IIncludableQueryable<Material, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Material> materialList = await _materialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialList;
    }

    public async Task<Material> AddAsync(Material material)
    {
        Material addedMaterial = await _materialRepository.AddAsync(material);

        return addedMaterial;
    }

    public async Task<Material> UpdateAsync(Material material)
    {
        Material updatedMaterial = await _materialRepository.UpdateAsync(material);

        return updatedMaterial;
    }

    public async Task<Material> DeleteAsync(Material material, bool permanent = false)
    {
        Material deletedMaterial = await _materialRepository.DeleteAsync(material);

        return deletedMaterial;
    }
}
