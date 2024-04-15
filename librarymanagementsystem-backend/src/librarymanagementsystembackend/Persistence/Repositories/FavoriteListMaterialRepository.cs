using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FavoriteListMaterialRepository : EfRepositoryBase<FavoriteListMaterial, Guid, BaseDbContext>, IFavoriteListMaterialRepository
{
    public FavoriteListMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}