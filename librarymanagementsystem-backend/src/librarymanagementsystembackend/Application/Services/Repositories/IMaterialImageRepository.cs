using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialImageRepository : IAsyncRepository<MaterialImage, Guid>, IRepository<MaterialImage, Guid>
{
}