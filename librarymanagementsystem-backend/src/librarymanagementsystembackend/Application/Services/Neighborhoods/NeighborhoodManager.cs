using Application.Features.Neighborhoods.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Neighborhoods;

public class NeighborhoodManager : INeighborhoodService
{
    private readonly INeighborhoodRepository _neighborhoodRepository;
    private readonly NeighborhoodBusinessRules _neighborhoodBusinessRules;

    public NeighborhoodManager(INeighborhoodRepository neighborhoodRepository, NeighborhoodBusinessRules neighborhoodBusinessRules)
    {
        _neighborhoodRepository = neighborhoodRepository;
        _neighborhoodBusinessRules = neighborhoodBusinessRules;
    }

    public async Task<Neighborhood?> GetAsync(
        Expression<Func<Neighborhood, bool>> predicate,
        Func<IQueryable<Neighborhood>, IIncludableQueryable<Neighborhood, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Neighborhood? neighborhood = await _neighborhoodRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return neighborhood;
    }

    public async Task<IPaginate<Neighborhood>?> GetListAsync(
        Expression<Func<Neighborhood, bool>>? predicate = null,
        Func<IQueryable<Neighborhood>, IOrderedQueryable<Neighborhood>>? orderBy = null,
        Func<IQueryable<Neighborhood>, IIncludableQueryable<Neighborhood, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Neighborhood> neighborhoodList = await _neighborhoodRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return neighborhoodList;
    }

    public async Task<Neighborhood> AddAsync(Neighborhood neighborhood)
    {
        Neighborhood addedNeighborhood = await _neighborhoodRepository.AddAsync(neighborhood);

        return addedNeighborhood;
    }

    public async Task<Neighborhood> UpdateAsync(Neighborhood neighborhood)
    {
        Neighborhood updatedNeighborhood = await _neighborhoodRepository.UpdateAsync(neighborhood);

        return updatedNeighborhood;
    }

    public async Task<Neighborhood> DeleteAsync(Neighborhood neighborhood, bool permanent = false)
    {
        Neighborhood deletedNeighborhood = await _neighborhoodRepository.DeleteAsync(neighborhood);

        return deletedNeighborhood;
    }
}
