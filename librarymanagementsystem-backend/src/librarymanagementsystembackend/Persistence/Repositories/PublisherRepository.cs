using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PublisherRepository : EfRepositoryBase<Publisher, Guid, BaseDbContext>, IPublisherRepository
{
    public PublisherRepository(BaseDbContext context) : base(context)
    {
    }
}