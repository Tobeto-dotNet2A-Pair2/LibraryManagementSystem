using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMemberAddressRepository : IAsyncRepository<MemberAddress, Guid>, IRepository<MemberAddress, Guid>
{
}