using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialPropertyRepository : EfRepositoryBase<MaterialProperty, Guid, BaseDbContext>, IMaterialPropertyRepository
{
    public MaterialPropertyRepository(BaseDbContext context) : base(context)
    {
    }
}