using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialRepository : EfRepositoryBase<Material, Guid, BaseDbContext>, IMaterialRepository
{
    public MaterialRepository(BaseDbContext context) : base(context)
    {
    }
}