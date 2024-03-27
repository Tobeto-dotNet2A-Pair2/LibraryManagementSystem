using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISocialMediaAccountRepository : IAsyncRepository<SocialMediaAccount, Guid>, IRepository<SocialMediaAccount, Guid>
{
}