using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITranslatorRepository : IAsyncRepository<Translator, Guid>, IRepository<Translator, Guid>
{
}