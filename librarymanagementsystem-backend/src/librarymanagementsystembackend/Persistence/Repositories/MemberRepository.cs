using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MemberRepository : EfRepositoryBase<Member, Guid, BaseDbContext>, IMemberRepository
{
    public MemberRepository(BaseDbContext context) : base(context)
    {
    }
}