using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorRepository : EfRepositoryBase<Author, Guid, BaseDbContext>, IAuthorRepository
{
    public AuthorRepository(BaseDbContext context) : base(context)
    {
    }
}