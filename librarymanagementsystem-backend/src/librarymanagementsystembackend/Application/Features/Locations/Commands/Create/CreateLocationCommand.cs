using Application.Features.Locations.Constants;
using Application.Features.Locations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Locations.Constants.LocationsOperationClaims;

namespace Application.Features.Locations.Commands.Create;

public class CreateLocationCommand : IRequest<CreatedLocationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string ShelfLineNumber { get; set; }
    public string ShelfFloor { get; set; }
    public string Shelf { get; set; }
    public string Corridor { get; set; }
    public string Floor { get; set; }

    public string[] Roles => [Admin, Write, LocationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLocations"];

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreatedLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly LocationBusinessRules _locationBusinessRules;

        public CreateLocationCommandHandler(IMapper mapper, ILocationRepository locationRepository,
                                         LocationBusinessRules locationBusinessRules)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _locationBusinessRules = locationBusinessRules;
        }

        public async Task<CreatedLocationResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            Location location = _mapper.Map<Location>(request);

            await _locationRepository.AddAsync(location);

            CreatedLocationResponse response = _mapper.Map<CreatedLocationResponse>(location);
            return response;
        }
    }
}