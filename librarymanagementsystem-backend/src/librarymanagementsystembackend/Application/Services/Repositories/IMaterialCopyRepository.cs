using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialCopyRepository : IAsyncRepository<MaterialCopy, Guid>, IRepository<MaterialCopy, Guid>
{
}