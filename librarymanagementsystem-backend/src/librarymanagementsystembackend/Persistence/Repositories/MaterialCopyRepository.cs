using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialCopyRepository : EfRepositoryBase<MaterialCopy, Guid, BaseDbContext>, IMaterialCopyRepository
{
    public MaterialCopyRepository(BaseDbContext context) : base(context)
    {
    }
}