using Application.Features.Cities.Constants;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Cities.Constants.CitiesOperationClaims;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommand : IRequest<CreatedCityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, CitiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCities"];

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreatedCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public CreateCityCommandHandler(IMapper mapper, ICityRepository cityRepository,
                                         CityBusinessRules cityBusinessRules)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<CreatedCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<City>(request);

            await _cityRepository.AddAsync(city);

            CreatedCityResponse response = _mapper.Map<CreatedCityResponse>(city);
            return response;
        }
    }
}