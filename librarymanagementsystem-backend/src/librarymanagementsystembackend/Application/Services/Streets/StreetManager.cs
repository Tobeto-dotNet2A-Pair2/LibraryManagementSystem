using Application.Features.Streets.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Streets;

public class StreetManager : IStreetService
{
    private readonly IStreetRepository _streetRepository;
    private readonly StreetBusinessRules _streetBusinessRules;

    public StreetManager(IStreetRepository streetRepository, StreetBusinessRules streetBusinessRules)
    {
        _streetRepository = streetRepository;
        _streetBusinessRules = streetBusinessRules;
    }

    public async Task<Street?> GetAsync(
        Expression<Func<Street, bool>> predicate,
        Func<IQueryable<Street>, IIncludableQueryable<Street, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Street? street = await _streetRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return street;
    }

    public async Task<IPaginate<Street>?> GetListAsync(
        Expression<Func<Street, bool>>? predicate = null,
        Func<IQueryable<Street>, IOrderedQueryable<Street>>? orderBy = null,
        Func<IQueryable<Street>, IIncludableQueryable<Street, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Street> streetList = await _streetRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return streetList;
    }

    public async Task<Street> AddAsync(Street street)
    {
        Street addedStreet = await _streetRepository.AddAsync(street);

        return addedStreet;
    }

    public async Task<Street> UpdateAsync(Street street)
    {
        Street updatedStreet = await _streetRepository.UpdateAsync(street);

        return updatedStreet;
    }

    public async Task<Street> DeleteAsync(Street street, bool permanent = false)
    {
        Street deletedStreet = await _streetRepository.DeleteAsync(street);

        return deletedStreet;
    }
}
