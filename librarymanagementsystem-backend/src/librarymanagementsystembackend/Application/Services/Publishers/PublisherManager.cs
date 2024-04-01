using Application.Features.Publishers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Publishers;

public class PublisherManager : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly PublisherBusinessRules _publisherBusinessRules;

    public PublisherManager(IPublisherRepository publisherRepository, PublisherBusinessRules publisherBusinessRules)
    {
        _publisherRepository = publisherRepository;
        _publisherBusinessRules = publisherBusinessRules;
    }

    public async Task<Publisher?> GetAsync(
        Expression<Func<Publisher, bool>> predicate,
        Func<IQueryable<Publisher>, IIncludableQueryable<Publisher, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Publisher? publisher = await _publisherRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return publisher;
    }

    public async Task<IPaginate<Publisher>?> GetListAsync(
        Expression<Func<Publisher, bool>>? predicate = null,
        Func<IQueryable<Publisher>, IOrderedQueryable<Publisher>>? orderBy = null,
        Func<IQueryable<Publisher>, IIncludableQueryable<Publisher, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Publisher> publisherList = await _publisherRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return publisherList;
    }

    public async Task<Publisher> AddAsync(Publisher publisher)
    {
        Publisher addedPublisher = await _publisherRepository.AddAsync(publisher);

        return addedPublisher;
    }

    public async Task<Publisher> UpdateAsync(Publisher publisher)
    {
        Publisher updatedPublisher = await _publisherRepository.UpdateAsync(publisher);

        return updatedPublisher;
    }

    public async Task<Publisher> DeleteAsync(Publisher publisher, bool permanent = false)
    {
        Publisher deletedPublisher = await _publisherRepository.DeleteAsync(publisher);

        return deletedPublisher;
    }
}
