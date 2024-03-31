using Application.Features.Penalties.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Penalties.Rules;

public class PenaltyBusinessRules : BaseBusinessRules
{
    private readonly IPenaltyRepository _penaltyRepository;
    private readonly ILocalizationService _localizationService;

    public PenaltyBusinessRules(IPenaltyRepository penaltyRepository, ILocalizationService localizationService)
    {
        _penaltyRepository = penaltyRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PenaltiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PenaltyShouldExistWhenSelected(Penalty? penalty)
    {
        if (penalty == null)
            await throwBusinessException(PenaltiesBusinessMessages.PenaltyNotExists);
    }

    public async Task PenaltyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Penalty? penalty = await _penaltyRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PenaltyShouldExistWhenSelected(penalty);
    }
}