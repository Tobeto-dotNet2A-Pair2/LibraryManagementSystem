using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPublisherMaterialRepository : IAsyncRepository<PublisherMaterial, Guid>, IRepository<PublisherMaterial, Guid>
{
}