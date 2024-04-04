using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MemberContactRepository : EfRepositoryBase<MemberContact, Guid, BaseDbContext>, IMemberContactRepository
{
    public MemberContactRepository(BaseDbContext context) : base(context)
    {
    }
}