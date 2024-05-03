using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Locations.Queries.GetList.GetAll;
public class GetAllLocationsQuery : IRequest<List<GetAllLocationsDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllLocations";
    public string? CacheGroupKey => "GetLocations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllLocationsHandler : IRequestHandler<GetAllLocationsQuery, List<GetAllLocationsDto>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetAllLocationsHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllLocationsDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Location> query = _locationRepository.Query();
            List<GetAllLocationsDto> allLocations = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllLocationsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allLocations;
        }
    }
}