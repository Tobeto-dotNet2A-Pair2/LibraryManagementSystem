using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface INeighborhoodRepository : IAsyncRepository<Neighborhood, Guid>, IRepository<Neighborhood, Guid>
{
}