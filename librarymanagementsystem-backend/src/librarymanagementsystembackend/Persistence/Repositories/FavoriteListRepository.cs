using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FavoriteListRepository : EfRepositoryBase<FavoriteList, Guid, BaseDbContext>, IFavoriteListRepository
{
    public FavoriteListRepository(BaseDbContext context) : base(context)
    {
    }
}