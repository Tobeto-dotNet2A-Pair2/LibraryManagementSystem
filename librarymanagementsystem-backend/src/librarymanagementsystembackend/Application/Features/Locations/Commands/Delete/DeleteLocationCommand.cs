using Application.Features.Locations.Constants;
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

namespace Application.Features.Locations.Commands.Delete;

public class DeleteLocationCommand : IRequest<DeletedLocationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, LocationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLocations"];

    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeletedLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly LocationBusinessRules _locationBusinessRules;

        public DeleteLocationCommandHandler(IMapper mapper, ILocationRepository locationRepository,
                                         LocationBusinessRules locationBusinessRules)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _locationBusinessRules = locationBusinessRules;
        }

        public async Task<DeletedLocationResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            Location? location = await _locationRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _locationBusinessRules.LocationShouldExistWhenSelected(location);

            await _locationRepository.DeleteAsync(location!);

            DeletedLocationResponse response = _mapper.Map<DeletedLocationResponse>(location);
            return response;
        }
    }
}