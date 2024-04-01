using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBorrowedMaterialRepository : IAsyncRepository<BorrowedMaterial, Guid>, IRepository<BorrowedMaterial, Guid>
{
}