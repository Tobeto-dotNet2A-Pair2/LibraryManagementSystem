using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StreetRepository : EfRepositoryBase<Street, Guid, BaseDbContext>, IStreetRepository
{
    public StreetRepository(BaseDbContext context) : base(context)
    {
    }
}