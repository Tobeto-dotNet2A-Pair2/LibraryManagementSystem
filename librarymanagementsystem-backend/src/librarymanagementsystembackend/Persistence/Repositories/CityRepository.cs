using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, Guid, BaseDbContext>, ICityRepository
{
    public CityRepository(BaseDbContext context) : base(context)
    {
    }
}