using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LanguageRepository : EfRepositoryBase<Language, Guid, BaseDbContext>, ILanguageRepository
{
    public LanguageRepository(BaseDbContext context) : base(context)
    {
    }
}