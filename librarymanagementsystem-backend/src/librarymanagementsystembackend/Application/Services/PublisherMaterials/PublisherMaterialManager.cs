using Application.Features.PublisherMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PublisherMaterials;

public class PublisherMaterialManager : IPublisherMaterialService
{
    private readonly IPublisherMaterialRepository _publisherMaterialRepository;
    private readonly PublisherMaterialBusinessRules _publisherMaterialBusinessRules;

    public PublisherMaterialManager(IPublisherMaterialRepository publisherMaterialRepository, PublisherMaterialBusinessRules publisherMaterialBusinessRules)
    {
        _publisherMaterialRepository = publisherMaterialRepository;
        _publisherMaterialBusinessRules = publisherMaterialBusinessRules;
    }

    public async Task<PublisherMaterial?> GetAsync(
        Expression<Func<PublisherMaterial, bool>> predicate,
        Func<IQueryable<PublisherMaterial>, IIncludableQueryable<PublisherMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PublisherMaterial? publisherMaterial = await _publisherMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return publisherMaterial;
    }

    public async Task<IPaginate<PublisherMaterial>?> GetListAsync(
        Expression<Func<PublisherMaterial, bool>>? predicate = null,
        Func<IQueryable<PublisherMaterial>, IOrderedQueryable<PublisherMaterial>>? orderBy = null,
        Func<IQueryable<PublisherMaterial>, IIncludableQueryable<PublisherMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PublisherMaterial> publisherMaterialList = await _publisherMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return publisherMaterialList;
    }

    public async Task<PublisherMaterial> AddAsync(PublisherMaterial publisherMaterial)
    {
        PublisherMaterial addedPublisherMaterial = await _publisherMaterialRepository.AddAsync(publisherMaterial);

        return addedPublisherMaterial;
    }

    public async Task<PublisherMaterial> UpdateAsync(PublisherMaterial publisherMaterial)
    {
        PublisherMaterial updatedPublisherMaterial = await _publisherMaterialRepository.UpdateAsync(publisherMaterial);

        return updatedPublisherMaterial;
    }

    public async Task<PublisherMaterial> DeleteAsync(PublisherMaterial publisherMaterial, bool permanent = false)
    {
        PublisherMaterial deletedPublisherMaterial = await _publisherMaterialRepository.DeleteAsync(publisherMaterial);

        return deletedPublisherMaterial;
    }
}
