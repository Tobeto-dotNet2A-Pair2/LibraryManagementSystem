using Application.Features.MaterialProperties.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialProperties;

public class MaterialPropertyManager : IMaterialPropertyService
{
    private readonly IMaterialPropertyRepository _materialPropertyRepository;
    private readonly MaterialPropertyBusinessRules _materialPropertyBusinessRules;

    public MaterialPropertyManager(IMaterialPropertyRepository materialPropertyRepository, MaterialPropertyBusinessRules materialPropertyBusinessRules)
    {
        _materialPropertyRepository = materialPropertyRepository;
        _materialPropertyBusinessRules = materialPropertyBusinessRules;
    }

    public async Task<MaterialProperty?> GetAsync(
        Expression<Func<MaterialProperty, bool>> predicate,
        Func<IQueryable<MaterialProperty>, IIncludableQueryable<MaterialProperty, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialProperty? materialProperty = await _materialPropertyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialProperty;
    }

    public async Task<IPaginate<MaterialProperty>?> GetListAsync(
        Expression<Func<MaterialProperty, bool>>? predicate = null,
        Func<IQueryable<MaterialProperty>, IOrderedQueryable<MaterialProperty>>? orderBy = null,
        Func<IQueryable<MaterialProperty>, IIncludableQueryable<MaterialProperty, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialProperty> materialPropertyList = await _materialPropertyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialPropertyList;
    }

    public async Task<MaterialProperty> AddAsync(MaterialProperty materialProperty)
    {
        MaterialProperty addedMaterialProperty = await _materialPropertyRepository.AddAsync(materialProperty);

        return addedMaterialProperty;
    }

    public async Task<MaterialProperty> UpdateAsync(MaterialProperty materialProperty)
    {
        MaterialProperty updatedMaterialProperty = await _materialPropertyRepository.UpdateAsync(materialProperty);

        return updatedMaterialProperty;
    }

    public async Task<MaterialProperty> DeleteAsync(MaterialProperty materialProperty, bool permanent = false)
    {
        MaterialProperty deletedMaterialProperty = await _materialPropertyRepository.DeleteAsync(materialProperty);

        return deletedMaterialProperty;
    }
}
