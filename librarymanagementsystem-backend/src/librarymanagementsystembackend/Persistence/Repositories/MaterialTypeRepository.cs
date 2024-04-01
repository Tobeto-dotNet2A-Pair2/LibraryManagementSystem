using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialTypeRepository : EfRepositoryBase<MaterialType, Guid, BaseDbContext>, IMaterialTypeRepository
{
    public MaterialTypeRepository(BaseDbContext context) : base(context)
    {
    }
}