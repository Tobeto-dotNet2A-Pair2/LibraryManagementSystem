using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialPropertyValueRepository : IAsyncRepository<MaterialPropertyValue, Guid>, IRepository<MaterialPropertyValue, Guid>
{
}