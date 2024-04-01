using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorRepository : IAsyncRepository<Author, Guid>, IRepository<Author, Guid>
{
}