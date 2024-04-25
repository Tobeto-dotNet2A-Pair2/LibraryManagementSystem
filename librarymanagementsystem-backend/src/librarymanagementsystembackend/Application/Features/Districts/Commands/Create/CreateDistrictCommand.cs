using Application.Features.Districts.Constants;
using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Districts.Constants.DistrictsOperationClaims;

namespace Application.Features.Districts.Commands.Create;

public class CreateDistrictCommand : IRequest<CreatedDistrictResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public string Name { get; set; }
    public Guid CityId { get; set; }

    public string[] Roles => [Admin, Write, DistrictsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDistricts"];

    public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommand, CreatedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictBusinessRules _districtBusinessRules;

        public CreateDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository,
                                         DistrictBusinessRules districtBusinessRules)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _districtBusinessRules = districtBusinessRules;
        }

        public async Task<CreatedDistrictResponse> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            District district = _mapper.Map<District>(request);

            await _districtRepository.AddAsync(district);

            CreatedDistrictResponse response = _mapper.Map<CreatedDistrictResponse>(district);
            return response;
        }
    }
}