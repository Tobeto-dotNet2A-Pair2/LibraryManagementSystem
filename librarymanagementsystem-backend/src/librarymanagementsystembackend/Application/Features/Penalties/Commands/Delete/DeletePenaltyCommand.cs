using Application.Features.Penalties.Constants;
using Application.Features.Penalties.Constants;
using Application.Features.Penalties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Penalties.Constants.PenaltiesOperationClaims;

namespace Application.Features.Penalties.Commands.Delete;

public class DeletePenaltyCommand : IRequest<DeletedPenaltyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PenaltiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPenalties"];

    public class DeletePenaltyCommandHandler : IRequestHandler<DeletePenaltyCommand, DeletedPenaltyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly PenaltyBusinessRules _penaltyBusinessRules;

        public DeletePenaltyCommandHandler(IMapper mapper, IPenaltyRepository penaltyRepository,
                                         PenaltyBusinessRules penaltyBusinessRules)
        {
            _mapper = mapper;
            _penaltyRepository = penaltyRepository;
            _penaltyBusinessRules = penaltyBusinessRules;
        }

        public async Task<DeletedPenaltyResponse> Handle(DeletePenaltyCommand request, CancellationToken cancellationToken)
        {
            Penalty? penalty = await _penaltyRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _penaltyBusinessRules.PenaltyShouldExistWhenSelected(penalty);

            await _penaltyRepository.DeleteAsync(penalty!);

            DeletedPenaltyResponse response = _mapper.Map<DeletedPenaltyResponse>(penalty);
            return response;
        }
    }
}