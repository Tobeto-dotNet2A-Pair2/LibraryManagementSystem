using Application.Features.MaterialTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialTypes;

public class MaterialTypeManager : IMaterialTypeService
{
    private readonly IMaterialTypeRepository _materialTypeRepository;
    private readonly MaterialTypeBusinessRules _materialTypeBusinessRules;

    public MaterialTypeManager(IMaterialTypeRepository materialTypeRepository, MaterialTypeBusinessRules materialTypeBusinessRules)
    {
        _materialTypeRepository = materialTypeRepository;
        _materialTypeBusinessRules = materialTypeBusinessRules;
    }

    public async Task<MaterialType?> GetAsync(
        Expression<Func<MaterialType, bool>> predicate,
        Func<IQueryable<MaterialType>, IIncludableQueryable<MaterialType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialType? materialType = await _materialTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialType;
    }

    public async Task<IPaginate<MaterialType>?> GetListAsync(
        Expression<Func<MaterialType, bool>>? predicate = null,
        Func<IQueryable<MaterialType>, IOrderedQueryable<MaterialType>>? orderBy = null,
        Func<IQueryable<MaterialType>, IIncludableQueryable<MaterialType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialType> materialTypeList = await _materialTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialTypeList;
    }

    public async Task<MaterialType> AddAsync(MaterialType materialType)
    {
        MaterialType addedMaterialType = await _materialTypeRepository.AddAsync(materialType);

        return addedMaterialType;
    }

    public async Task<MaterialType> UpdateAsync(MaterialType materialType)
    {
        MaterialType updatedMaterialType = await _materialTypeRepository.UpdateAsync(materialType);

        return updatedMaterialType;
    }

    public async Task<MaterialType> DeleteAsync(MaterialType materialType, bool permanent = false)
    {
        MaterialType deletedMaterialType = await _materialTypeRepository.DeleteAsync(materialType);

        return deletedMaterialType;
    }
}
