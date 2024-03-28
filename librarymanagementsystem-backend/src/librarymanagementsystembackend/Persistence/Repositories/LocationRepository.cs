using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LocationRepository : EfRepositoryBase<Location, Guid, BaseDbContext>, ILocationRepository
{
    public LocationRepository(BaseDbContext context) : base(context)
    {
    }
}