using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFavoriteListMaterialRepository : IAsyncRepository<FavoriteListMaterial, Guid>, IRepository<FavoriteListMaterial, Guid>
{
}