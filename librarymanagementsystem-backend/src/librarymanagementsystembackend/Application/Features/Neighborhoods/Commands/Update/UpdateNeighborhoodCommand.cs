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

namespace Application.Features.Neighborhoods.Commands.Update;

public class UpdateNeighborhoodCommand : IRequest<UpdatedNeighborhoodResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DistrictId { get; set; }

    public string[] Roles => [Admin, Write, NeighborhoodsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetNeighborhoods"];

    public class UpdateNeighborhoodCommandHandler : IRequestHandler<UpdateNeighborhoodCommand, UpdatedNeighborhoodResponse>
    {
        private readonly IMapper _mapper;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly NeighborhoodBusinessRules _neighborhoodBusinessRules;

        public UpdateNeighborhoodCommandHandler(IMapper mapper, INeighborhoodRepository neighborhoodRepository,
                                         NeighborhoodBusinessRules neighborhoodBusinessRules)
        {
            _mapper = mapper;
            _neighborhoodRepository = neighborhoodRepository;
            _neighborhoodBusinessRules = neighborhoodBusinessRules;
        }

        public async Task<UpdatedNeighborhoodResponse> Handle(UpdateNeighborhoodCommand request, CancellationToken cancellationToken)
        {
            Neighborhood? neighborhood = await _neighborhoodRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _neighborhoodBusinessRules.NeighborhoodShouldExistWhenSelected(neighborhood);
            neighborhood = _mapper.Map(request, neighborhood);

            await _neighborhoodRepository.UpdateAsync(neighborhood!);

            UpdatedNeighborhoodResponse response = _mapper.Map<UpdatedNeighborhoodResponse>(neighborhood);
            return response;
        }
    }
}