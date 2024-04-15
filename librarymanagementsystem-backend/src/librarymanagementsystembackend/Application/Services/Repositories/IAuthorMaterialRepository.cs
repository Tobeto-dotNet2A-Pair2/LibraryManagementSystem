using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorMaterialRepository : IAsyncRepository<AuthorMaterial, Guid>, IRepository<AuthorMaterial, Guid>
{
}