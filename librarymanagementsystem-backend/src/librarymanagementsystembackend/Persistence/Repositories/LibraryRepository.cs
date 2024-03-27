using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LibraryRepository : EfRepositoryBase<Library, Guid, BaseDbContext>, ILibraryRepository
{
    public LibraryRepository(BaseDbContext context) : base(context)
    {
    }
}