using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialImageRepository : EfRepositoryBase<MaterialImage, Guid, BaseDbContext>, IMaterialImageRepository
{
    public MaterialImageRepository(BaseDbContext context) : base(context)
    {
    }
}