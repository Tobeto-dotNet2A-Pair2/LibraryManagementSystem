using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILibraryRepository : IAsyncRepository<Library, Guid>, IRepository<Library, Guid>
{
}