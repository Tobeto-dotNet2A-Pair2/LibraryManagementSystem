using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenreRepository : EfRepositoryBase<Genre, Guid, BaseDbContext>, IGenreRepository
{
    public GenreRepository(BaseDbContext context) : base(context)
    {
    }
}