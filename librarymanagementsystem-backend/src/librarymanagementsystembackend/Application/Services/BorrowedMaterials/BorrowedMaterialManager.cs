using Application.Features.BorrowedMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BorrowedMaterials;

public class BorrowedMaterialManager : IBorrowedMaterialService
{
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;

    public BorrowedMaterialManager(IBorrowedMaterialRepository borrowedMaterialRepository, BorrowedMaterialBusinessRules borrowedMaterialBusinessRules)
    {
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
    }

    public async Task<BorrowedMaterial?> GetAsync(
        Expression<Func<BorrowedMaterial, bool>> predicate,
        Func<IQueryable<BorrowedMaterial>, IIncludableQueryable<BorrowedMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return borrowedMaterial;
    }

    public async Task<IPaginate<BorrowedMaterial>?> GetListAsync(
        Expression<Func<BorrowedMaterial, bool>>? predicate = null,
        Func<IQueryable<BorrowedMaterial>, IOrderedQueryable<BorrowedMaterial>>? orderBy = null,
        Func<IQueryable<BorrowedMaterial>, IIncludableQueryable<BorrowedMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BorrowedMaterial> borrowedMaterialList = await _borrowedMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return borrowedMaterialList;
    }

    public async Task<BorrowedMaterial> AddAsync(BorrowedMaterial borrowedMaterial)
    {
        BorrowedMaterial addedBorrowedMaterial = await _borrowedMaterialRepository.AddAsync(borrowedMaterial);

        return addedBorrowedMaterial;
    }

    public async Task<BorrowedMaterial> UpdateAsync(BorrowedMaterial borrowedMaterial)
    {
        BorrowedMaterial updatedBorrowedMaterial = await _borrowedMaterialRepository.UpdateAsync(borrowedMaterial);

        return updatedBorrowedMaterial;
    }

    public async Task<BorrowedMaterial> DeleteAsync(BorrowedMaterial borrowedMaterial, bool permanent = false)
    {
        BorrowedMaterial deletedBorrowedMaterial = await _borrowedMaterialRepository.DeleteAsync(borrowedMaterial);

        return deletedBorrowedMaterial;
    }
}
