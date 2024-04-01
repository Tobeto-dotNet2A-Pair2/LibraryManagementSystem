using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AddressRepository : EfRepositoryBase<Address, Guid, BaseDbContext>, IAddressRepository
{
    public AddressRepository(BaseDbContext context) : base(context)
    {
    }
}