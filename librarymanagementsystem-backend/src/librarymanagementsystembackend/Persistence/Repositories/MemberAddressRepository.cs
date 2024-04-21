using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MemberAddressRepository : EfRepositoryBase<MemberAddress, Guid, BaseDbContext>, IMemberAddressRepository
{
    public MemberAddressRepository(BaseDbContext context) : base(context)
    {
    }
}