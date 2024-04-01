using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PenaltyRepository : EfRepositoryBase<Penalty, Guid, BaseDbContext>, IPenaltyRepository
{
    public PenaltyRepository(BaseDbContext context) : base(context)
    {
    }
}