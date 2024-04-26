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

namespace Application.Features.Locations.Commands.Update;

public class UpdateLocationCommand : IRequest<UpdatedLocationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public string? ShelfLineNumber { get; set; }
    public string? ShelfFloor { get; set; }
    public string? Shelf { get; set; }
    public string? Corridor { get; set; }
    public string? Floor { get; set; }
    public string? FullLocationMap { get; set; }

    public string[] Roles => [Admin, Write, LocationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLocations"];

    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdatedLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly LocationBusinessRules _locationBusinessRules;

        public UpdateLocationCommandHandler(IMapper mapper, ILocationRepository locationRepository,
                                         LocationBusinessRules locationBusinessRules)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _locationBusinessRules = locationBusinessRules;
        }

        public async Task<UpdatedLocationResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            Location? location = await _locationRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _locationBusinessRules.LocationShouldExistWhenSelected(location);
            location = _mapper.Map(request, location);

            await _locationRepository.UpdateAsync(location!);

            UpdatedLocationResponse response = _mapper.Map<UpdatedLocationResponse>(location);
            return response;
        }
    }
}