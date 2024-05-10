using Application.Features.Penalties.Constants;
using Application.Features.Penalties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Penalties.Constants.PenaltiesOperationClaims;

namespace Application.Features.Penalties.Queries.GetById;

public class GetByIdPenaltyQuery : IRequest<GetByIdPenaltyResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPenaltyQueryHandler : IRequestHandler<GetByIdPenaltyQuery, GetByIdPenaltyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly PenaltyBusinessRules _penaltyBusinessRules;

        public GetByIdPenaltyQueryHandler(IMapper mapper, IPenaltyRepository penaltyRepository, PenaltyBusinessRules penaltyBusinessRules)
        {
            _mapper = mapper;
            _penaltyRepository = penaltyRepository;
            _penaltyBusinessRules = penaltyBusinessRules;
        }

        public async Task<GetByIdPenaltyResponse> Handle(GetByIdPenaltyQuery request, CancellationToken cancellationToken)
        {
            Penalty? penalty = await _penaltyRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _penaltyBusinessRules.PenaltyShouldExistWhenSelected(penalty);

            GetByIdPenaltyResponse response = _mapper.Map<GetByIdPenaltyResponse>(penalty);
            return response;
        }
    }
}