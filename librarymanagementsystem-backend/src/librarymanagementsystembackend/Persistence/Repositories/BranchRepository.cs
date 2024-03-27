using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BranchRepository : EfRepositoryBase<Branch, Guid, BaseDbContext>, IBranchRepository
{
    public BranchRepository(BaseDbContext context) : base(context)
    {
    }
}