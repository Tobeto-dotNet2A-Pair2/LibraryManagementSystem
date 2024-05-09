using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    private readonly BaseDbContext _dbContext;

    public OperationClaimRepository(BaseDbContext context)
        : base(context)
    {
        _dbContext = context;
    }
    public async Task<List<GetByRoleNameDto>> GetByRoleNameAsync(List<string> roleNames)
    {
        return await _dbContext.OperationClaims.Where(a => roleNames.Contains(a.Name))
            .Select(a => new GetByRoleNameDto()
            {
                Name = a.Name,
                Id = a.Id

            }).ToListAsync();
    }
}
