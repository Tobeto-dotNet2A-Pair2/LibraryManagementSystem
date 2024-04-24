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

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommand : IRequest<UpdatedPenaltyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public decimal TotalMaterialDebt { get; set; }
    public int DayDelay { get; set; }
    public Guid BorrowedMaterialId { get; set; }

    public string[] Roles => [Admin, Write, PenaltiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPenalties"];

    public class UpdatePenaltyCommandHandler : IRequestHandler<UpdatePenaltyCommand, UpdatedPenaltyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly PenaltyBusinessRules _penaltyBusinessRules;

        public UpdatePenaltyCommandHandler(IMapper mapper, IPenaltyRepository penaltyRepository,
                                         PenaltyBusinessRules penaltyBusinessRules)
        {
            _mapper = mapper;
            _penaltyRepository = penaltyRepository;
            _penaltyBusinessRules = penaltyBusinessRules;
        }

        public async Task<UpdatedPenaltyResponse> Handle(UpdatePenaltyCommand request, CancellationToken cancellationToken)
        {
            Penalty? penalty = await _penaltyRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _penaltyBusinessRules.PenaltyShouldExistWhenSelected(penalty);
            penalty = _mapper.Map(request, penalty);

            await _penaltyRepository.UpdateAsync(penalty!);

            UpdatedPenaltyResponse response = _mapper.Map<UpdatedPenaltyResponse>(penalty);
            return response;
        }
    }
}