using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PublisherMaterials;

public interface IPublisherMaterialService
{
    Task<PublisherMaterial?> GetAsync(
        Expression<Func<PublisherMaterial, bool>> predicate,
        Func<IQueryable<PublisherMaterial>, IIncludableQueryable<PublisherMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PublisherMaterial>?> GetListAsync(
        Expression<Func<PublisherMaterial, bool>>? predicate = null,
        Func<IQueryable<PublisherMaterial>, IOrderedQueryable<PublisherMaterial>>? orderBy = null,
        Func<IQueryable<PublisherMaterial>, IIncludableQueryable<PublisherMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PublisherMaterial> AddAsync(PublisherMaterial publisherMaterial);
    Task<PublisherMaterial> UpdateAsync(PublisherMaterial publisherMaterial);
    Task<PublisherMaterial> DeleteAsync(PublisherMaterial publisherMaterial, bool permanent = false);
}
