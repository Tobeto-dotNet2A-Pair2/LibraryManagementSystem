using Application.Features.Streets.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Streets.Rules;

public class StreetBusinessRules : BaseBusinessRules
{
    private readonly IStreetRepository _streetRepository;
    private readonly ILocalizationService _localizationService;

    public StreetBusinessRules(IStreetRepository streetRepository, ILocalizationService localizationService)
    {
        _streetRepository = streetRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StreetsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StreetShouldExistWhenSelected(Street? street)
    {
        if (street == null)
            await throwBusinessException(StreetsBusinessMessages.StreetNotExists);
    }

    public async Task StreetIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Street? street = await _streetRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StreetShouldExistWhenSelected(street);
    }
}