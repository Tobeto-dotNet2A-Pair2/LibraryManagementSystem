using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBorrowMaterialRepository : IAsyncRepository<BorrowMaterial, Guid>, IRepository<BorrowMaterial, Guid>
{
}