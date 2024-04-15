using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PublisherMaterialRepository : EfRepositoryBase<PublisherMaterial, Guid, BaseDbContext>, IPublisherMaterialRepository
{
    public PublisherMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}