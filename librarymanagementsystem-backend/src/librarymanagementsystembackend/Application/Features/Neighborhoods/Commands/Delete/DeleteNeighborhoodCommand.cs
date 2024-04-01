using Application.Features.Neighborhoods.Constants;
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

namespace Application.Features.Neighborhoods.Commands.Delete;

public class DeleteNeighborhoodCommand : IRequest<DeletedNeighborhoodResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, NeighborhoodsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetNeighborhoods"];

    public class DeleteNeighborhoodCommandHandler : IRequestHandler<DeleteNeighborhoodCommand, DeletedNeighborhoodResponse>
    {
        private readonly IMapper _mapper;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly NeighborhoodBusinessRules _neighborhoodBusinessRules;

        public DeleteNeighborhoodCommandHandler(IMapper mapper, INeighborhoodRepository neighborhoodRepository,
                                         NeighborhoodBusinessRules neighborhoodBusinessRules)
        {
            _mapper = mapper;
            _neighborhoodRepository = neighborhoodRepository;
            _neighborhoodBusinessRules = neighborhoodBusinessRules;
        }

        public async Task<DeletedNeighborhoodResponse> Handle(DeleteNeighborhoodCommand request, CancellationToken cancellationToken)
        {
            Neighborhood? neighborhood = await _neighborhoodRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _neighborhoodBusinessRules.NeighborhoodShouldExistWhenSelected(neighborhood);

            await _neighborhoodRepository.DeleteAsync(neighborhood!);

            DeletedNeighborhoodResponse response = _mapper.Map<DeletedNeighborhoodResponse>(neighborhood);
            return response;
        }
    }
}