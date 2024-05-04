using Application.Features.BorrowedMaterials.Dtos;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialCopies;

public interface IMaterialCopyService
{
    Task<MaterialCopy?> GetAsync(
        Expression<Func<MaterialCopy, bool>> predicate,
        Func<IQueryable<MaterialCopy>, IIncludableQueryable<MaterialCopy, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialCopy>?> GetListAsync(
        Expression<Func<MaterialCopy, bool>>? predicate = null,
        Func<IQueryable<MaterialCopy>, IOrderedQueryable<MaterialCopy>>? orderBy = null,
        Func<IQueryable<MaterialCopy>, IIncludableQueryable<MaterialCopy, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialCopy> AddAsync(MaterialCopy materialCopy);
    Task<MaterialCopy> UpdateAsync(MaterialCopy materialCopy);
    Task<MaterialCopy> DeleteAsync(MaterialCopy materialCopy, bool permanent = false);

    Task<GetForBorrowDto> GetForBorrow(Guid id);

    Task UpdateAfterRefund(Guid materialCopyId);
}
