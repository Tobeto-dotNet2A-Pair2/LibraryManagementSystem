using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SocialMediaAccountRepository : EfRepositoryBase<SocialMediaAccount, Guid, BaseDbContext>, ISocialMediaAccountRepository
{
    public SocialMediaAccountRepository(BaseDbContext context) : base(context)
    {
    }
}