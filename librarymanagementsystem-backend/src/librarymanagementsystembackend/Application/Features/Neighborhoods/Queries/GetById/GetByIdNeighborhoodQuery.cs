using Application.Features.Neighborhoods.Constants;
using Application.Features.Neighborhoods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Neighborhoods.Constants.NeighborhoodsOperationClaims;

namespace Application.Features.Neighborhoods.Queries.GetById;

public class GetByIdNeighborhoodQuery : IRequest<GetByIdNeighborhoodResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdNeighborhoodQueryHandler : IRequestHandler<GetByIdNeighborhoodQuery, GetByIdNeighborhoodResponse>
    {
        private readonly IMapper _mapper;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly NeighborhoodBusinessRules _neighborhoodBusinessRules;

        public GetByIdNeighborhoodQueryHandler(IMapper mapper, INeighborhoodRepository neighborhoodRepository, NeighborhoodBusinessRules neighborhoodBusinessRules)
        {
            _mapper = mapper;
            _neighborhoodRepository = neighborhoodRepository;
            _neighborhoodBusinessRules = neighborhoodBusinessRules;
        }

        public async Task<GetByIdNeighborhoodResponse> Handle(GetByIdNeighborhoodQuery request, CancellationToken cancellationToken)
        {
            Neighborhood? neighborhood = await _neighborhoodRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _neighborhoodBusinessRules.NeighborhoodShouldExistWhenSelected(neighborhood);

            GetByIdNeighborhoodResponse response = _mapper.Map<GetByIdNeighborhoodResponse>(neighborhood);
            return response;
        }
    }
}