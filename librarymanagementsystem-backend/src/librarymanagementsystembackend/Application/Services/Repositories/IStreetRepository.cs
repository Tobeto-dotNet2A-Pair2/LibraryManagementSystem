using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStreetRepository : IAsyncRepository<Street, Guid>, IRepository<Street, Guid>
{
}