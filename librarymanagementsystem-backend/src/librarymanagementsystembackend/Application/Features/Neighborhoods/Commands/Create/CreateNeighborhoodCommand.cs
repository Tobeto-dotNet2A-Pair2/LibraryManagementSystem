using Application.Features.Neighborhoods.Constants;
using Application.Features.Neighborhoods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Neighborhoods.Constants.NeighborhoodsOperationClaims;

namespace Application.Features.Neighborhoods.Commands.Create;

public class CreateNeighborhoodCommand : IRequest<CreatedNeighborhoodResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string NeighborhoodName { get; set; }
    public Guid DistrictId { get; set; }

    public string[] Roles => [Admin, Write, NeighborhoodsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetNeighborhoods"];

    public class CreateNeighborhoodCommandHandler : IRequestHandler<CreateNeighborhoodCommand, CreatedNeighborhoodResponse>
    {
        private readonly IMapper _mapper;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly NeighborhoodBusinessRules _neighborhoodBusinessRules;

        public CreateNeighborhoodCommandHandler(IMapper mapper, INeighborhoodRepository neighborhoodRepository,
                                         NeighborhoodBusinessRules neighborhoodBusinessRules)
        {
            _mapper = mapper;
            _neighborhoodRepository = neighborhoodRepository;
            _neighborhoodBusinessRules = neighborhoodBusinessRules;
        }

        public async Task<CreatedNeighborhoodResponse> Handle(CreateNeighborhoodCommand request, CancellationToken cancellationToken)
        {
            Neighborhood neighborhood = _mapper.Map<Neighborhood>(request);

            await _neighborhoodRepository.AddAsync(neighborhood);

            CreatedNeighborhoodResponse response = _mapper.Map<CreatedNeighborhoodResponse>(neighborhood);
            return response;
        }
    }
}