using Application.Features.Locations.Constants;
using Application.Features.Locations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Locations.Constants.LocationsOperationClaims;

namespace Application.Features.Locations.Queries.GetById;

public class GetByIdLocationQuery : IRequest<GetByIdLocationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, GetByIdLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly LocationBusinessRules _locationBusinessRules;

        public GetByIdLocationQueryHandler(IMapper mapper, ILocationRepository locationRepository, LocationBusinessRules locationBusinessRules)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _locationBusinessRules = locationBusinessRules;
        }

        public async Task<GetByIdLocationResponse> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
        {
            Location? location = await _locationRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _locationBusinessRules.LocationShouldExistWhenSelected(location);

            GetByIdLocationResponse response = _mapper.Map<GetByIdLocationResponse>(location);
            return response;
        }
    }
}