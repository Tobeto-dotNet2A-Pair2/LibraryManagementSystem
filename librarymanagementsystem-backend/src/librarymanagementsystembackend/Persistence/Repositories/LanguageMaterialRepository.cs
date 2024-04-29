using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LanguageMaterialRepository : EfRepositoryBase<LanguageMaterial, Guid, BaseDbContext>, ILanguageMaterialRepository
{
    public LanguageMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}