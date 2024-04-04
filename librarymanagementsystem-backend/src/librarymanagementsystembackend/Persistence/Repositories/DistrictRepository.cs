using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DistrictRepository : EfRepositoryBase<District, Guid, BaseDbContext>, IDistrictRepository
{
    public DistrictRepository(BaseDbContext context) : base(context)
    {
    }
}