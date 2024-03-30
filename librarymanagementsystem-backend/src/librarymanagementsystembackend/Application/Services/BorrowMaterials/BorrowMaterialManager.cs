using Application.Features.BorrowMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BorrowMaterials;

public class BorrowMaterialManager : IBorrowMaterialService
{
    private readonly IBorrowMaterialRepository _borrowMaterialRepository;
    private readonly BorrowMaterialBusinessRules _borrowMaterialBusinessRules;

    public BorrowMaterialManager(IBorrowMaterialRepository borrowMaterialRepository, BorrowMaterialBusinessRules borrowMaterialBusinessRules)
    {
        _borrowMaterialRepository = borrowMaterialRepository;
        _borrowMaterialBusinessRules = borrowMaterialBusinessRules;
    }

    public async Task<BorrowMaterial?> GetAsync(
        Expression<Func<BorrowMaterial, bool>> predicate,
        Func<IQueryable<BorrowMaterial>, IIncludableQueryable<BorrowMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BorrowMaterial? borrowMaterial = await _borrowMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return borrowMaterial;
    }

    public async Task<IPaginate<BorrowMaterial>?> GetListAsync(
        Expression<Func<BorrowMaterial, bool>>? predicate = null,
        Func<IQueryable<BorrowMaterial>, IOrderedQueryable<BorrowMaterial>>? orderBy = null,
        Func<IQueryable<BorrowMaterial>, IIncludableQueryable<BorrowMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BorrowMaterial> borrowMaterialList = await _borrowMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return borrowMaterialList;
    }

    public async Task<BorrowMaterial> AddAsync(BorrowMaterial borrowMaterial)
    {
        BorrowMaterial addedBorrowMaterial = await _borrowMaterialRepository.AddAsync(borrowMaterial);

        return addedBorrowMaterial;
    }

    public async Task<BorrowMaterial> UpdateAsync(BorrowMaterial borrowMaterial)
    {
        BorrowMaterial updatedBorrowMaterial = await _borrowMaterialRepository.UpdateAsync(borrowMaterial);

        return updatedBorrowMaterial;
    }

    public async Task<BorrowMaterial> DeleteAsync(BorrowMaterial borrowMaterial, bool permanent = false)
    {
        BorrowMaterial deletedBorrowMaterial = await _borrowMaterialRepository.DeleteAsync(borrowMaterial);

        return deletedBorrowMaterial;
    }
}
