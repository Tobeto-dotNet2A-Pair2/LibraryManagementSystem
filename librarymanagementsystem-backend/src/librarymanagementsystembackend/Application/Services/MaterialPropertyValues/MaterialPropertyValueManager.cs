using Application.Features.MaterialPropertyValues.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialPropertyValues;

public class MaterialPropertyValueManager : IMaterialPropertyValueService
{
    private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
    private readonly MaterialPropertyValueBusinessRules _materialPropertyValueBusinessRules;

    public MaterialPropertyValueManager(IMaterialPropertyValueRepository materialPropertyValueRepository, MaterialPropertyValueBusinessRules materialPropertyValueBusinessRules)
    {
        _materialPropertyValueRepository = materialPropertyValueRepository;
        _materialPropertyValueBusinessRules = materialPropertyValueBusinessRules;
    }

    public async Task<MaterialPropertyValue?> GetAsync(
        Expression<Func<MaterialPropertyValue, bool>> predicate,
        Func<IQueryable<MaterialPropertyValue>, IIncludableQueryable<MaterialPropertyValue, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialPropertyValue? materialPropertyValue = await _materialPropertyValueRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialPropertyValue;
    }

    public async Task<IPaginate<MaterialPropertyValue>?> GetListAsync(
        Expression<Func<MaterialPropertyValue, bool>>? predicate = null,
        Func<IQueryable<MaterialPropertyValue>, IOrderedQueryable<MaterialPropertyValue>>? orderBy = null,
        Func<IQueryable<MaterialPropertyValue>, IIncludableQueryable<MaterialPropertyValue, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialPropertyValue> materialPropertyValueList = await _materialPropertyValueRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialPropertyValueList;
    }

    public async Task<MaterialPropertyValue> AddAsync(MaterialPropertyValue materialPropertyValue)
    {
        MaterialPropertyValue addedMaterialPropertyValue = await _materialPropertyValueRepository.AddAsync(materialPropertyValue);

        return addedMaterialPropertyValue;
    }

    public async Task<MaterialPropertyValue> UpdateAsync(MaterialPropertyValue materialPropertyValue)
    {
        MaterialPropertyValue updatedMaterialPropertyValue = await _materialPropertyValueRepository.UpdateAsync(materialPropertyValue);

        return updatedMaterialPropertyValue;
    }

    public async Task<MaterialPropertyValue> DeleteAsync(MaterialPropertyValue materialPropertyValue, bool permanent = false)
    {
        MaterialPropertyValue deletedMaterialPropertyValue = await _materialPropertyValueRepository.DeleteAsync(materialPropertyValue);

        return deletedMaterialPropertyValue;
    }
}
