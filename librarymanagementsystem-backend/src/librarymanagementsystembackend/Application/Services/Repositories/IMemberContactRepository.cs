using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMemberContactRepository : IAsyncRepository<MemberContact, Guid>, IRepository<MemberContact, Guid>
{
}