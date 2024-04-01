using Application.Features.Locations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Locations;

public class LocationManager : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly LocationBusinessRules _locationBusinessRules;

    public LocationManager(ILocationRepository locationRepository, LocationBusinessRules locationBusinessRules)
    {
        _locationRepository = locationRepository;
        _locationBusinessRules = locationBusinessRules;
    }

    public async Task<Location?> GetAsync(
        Expression<Func<Location, bool>> predicate,
        Func<IQueryable<Location>, IIncludableQueryable<Location, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Location? location = await _locationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return location;
    }

    public async Task<IPaginate<Location>?> GetListAsync(
        Expression<Func<Location, bool>>? predicate = null,
        Func<IQueryable<Location>, IOrderedQueryable<Location>>? orderBy = null,
        Func<IQueryable<Location>, IIncludableQueryable<Location, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Location> locationList = await _locationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return locationList;
    }

    public async Task<Location> AddAsync(Location location)
    {
        Location addedLocation = await _locationRepository.AddAsync(location);

        return addedLocation;
    }

    public async Task<Location> UpdateAsync(Location location)
    {
        Location updatedLocation = await _locationRepository.UpdateAsync(location);

        return updatedLocation;
    }

    public async Task<Location> DeleteAsync(Location location, bool permanent = false)
    {
        Location deletedLocation = await _locationRepository.DeleteAsync(location);

        return deletedLocation;
    }
}
