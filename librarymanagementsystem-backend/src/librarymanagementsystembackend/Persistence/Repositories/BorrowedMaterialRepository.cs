using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BorrowedMaterialRepository : EfRepositoryBase<BorrowedMaterial, Guid, BaseDbContext>, IBorrowedMaterialRepository
{
    public BorrowedMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}