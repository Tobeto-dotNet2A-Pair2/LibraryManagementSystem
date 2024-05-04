using Application.Features.BorrowedMaterials.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Dynamic.Core;

namespace Persistence.Repositories;

public class BorrowedMaterialRepository : EfRepositoryBase<BorrowedMaterial, Guid, BaseDbContext>, IBorrowedMaterialRepository
{
    private readonly BaseDbContext _baseDbContext;
    public BorrowedMaterialRepository(BaseDbContext context, BaseDbContext baseDbContext) : base(context)
    {
        _baseDbContext = baseDbContext;
    }
    
    /// <summary>
    /// GetMemberDeptForBorrowedMaterialCopyAsync
    /// </summary>
    /// <param name="memberId"></param>
    /// <param name="materialCopyId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetMemberDeptForBorrowedMaterialDto> GetMemberDeptForBorrowedMaterialCopyAsync(Guid memberId, Guid materialCopyId, CancellationToken cancellationToken)
    { 
        var borrowedMaterial = await _baseDbContext.BorrowedMaterials
            .Include(a => a.MaterialCopy)
            .ThenInclude(a => a.Material)
            .FirstOrDefaultAsync(a => a.MemberId == memberId &&
                                      a.MaterialCopyId == materialCopyId &&
                                      !a.IsReturned, cancellationToken: cancellationToken);
        
            int totalDelayDays = (DateTime.UtcNow - borrowedMaterial!.ReturnDate).Days;
            decimal? totalDebt = totalDelayDays * borrowedMaterial.MaterialCopy.Material.PunishmentAmount;
            return new GetMemberDeptForBorrowedMaterialDto()
            {
                TotalDebt = totalDebt!.Value, 
                DelayDay = totalDelayDays,
            };
    }
}