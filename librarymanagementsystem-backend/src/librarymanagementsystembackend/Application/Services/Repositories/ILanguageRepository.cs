using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILanguageRepository : IAsyncRepository<Language, Guid>, IRepository<Language, Guid>
{
}