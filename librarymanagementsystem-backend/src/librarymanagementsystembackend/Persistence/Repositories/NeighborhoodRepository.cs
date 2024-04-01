using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class NeighborhoodRepository : EfRepositoryBase<Neighborhood, Guid, BaseDbContext>, INeighborhoodRepository
{
    public NeighborhoodRepository(BaseDbContext context) : base(context)
    {
    }
}