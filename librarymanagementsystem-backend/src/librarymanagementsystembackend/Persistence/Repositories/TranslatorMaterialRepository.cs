using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TranslatorMaterialRepository : EfRepositoryBase<TranslatorMaterial, Guid, BaseDbContext>, ITranslatorMaterialRepository
{
    public TranslatorMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}