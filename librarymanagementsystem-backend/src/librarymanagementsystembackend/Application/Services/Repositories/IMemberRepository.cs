using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMemberRepository : IAsyncRepository<Member, Guid>, IRepository<Member, Guid>
{
}