using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorMaterialRepository : EfRepositoryBase<AuthorMaterial, Guid, BaseDbContext>, IAuthorMaterialRepository
{
    public AuthorMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}