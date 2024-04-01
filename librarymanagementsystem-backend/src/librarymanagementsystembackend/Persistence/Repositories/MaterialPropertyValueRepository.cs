using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialPropertyValueRepository : EfRepositoryBase<MaterialPropertyValue, Guid, BaseDbContext>, IMaterialPropertyValueRepository
{
    public MaterialPropertyValueRepository(BaseDbContext context) : base(context)
    {
    }
}