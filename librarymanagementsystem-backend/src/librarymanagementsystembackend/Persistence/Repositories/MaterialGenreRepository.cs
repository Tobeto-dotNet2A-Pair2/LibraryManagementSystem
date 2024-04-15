using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialGenreRepository : EfRepositoryBase<MaterialGenre, Guid, BaseDbContext>, IMaterialGenreRepository
{
    public MaterialGenreRepository(BaseDbContext context) : base(context)
    {
    }
}