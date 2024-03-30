using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BorrowMaterialRepository : EfRepositoryBase<BorrowMaterial, Guid, BaseDbContext>, IBorrowMaterialRepository
{
    public BorrowMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}