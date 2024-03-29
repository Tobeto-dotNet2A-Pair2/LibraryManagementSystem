using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFavoriteListRepository : IAsyncRepository<FavoriteList, Guid>, IRepository<FavoriteList, Guid>
{
}