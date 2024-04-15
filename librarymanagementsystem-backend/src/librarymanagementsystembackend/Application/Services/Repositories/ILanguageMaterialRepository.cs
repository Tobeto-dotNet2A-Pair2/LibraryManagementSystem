using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILanguageMaterialRepository : IAsyncRepository<LanguageMaterial, Guid>, IRepository<LanguageMaterial, Guid>
{
}