using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGenreRepository : IAsyncRepository<Genre, Guid>, IRepository<Genre, Guid>
{
}