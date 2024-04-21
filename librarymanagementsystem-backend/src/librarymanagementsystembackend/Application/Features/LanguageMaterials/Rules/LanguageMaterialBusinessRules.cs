using Application.Features.LanguageMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.LanguageMaterials.Rules;

public class LanguageMaterialBusinessRules : BaseBusinessRules
{
    private readonly ILanguageMaterialRepository _languageMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public LanguageMaterialBusinessRules(ILanguageMaterialRepository languageMaterialRepository, ILocalizationService localizationService)
    {
        _languageMaterialRepository = languageMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LanguageMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LanguageMaterialShouldExistWhenSelected(LanguageMaterial? languageMaterial)
    {
        if (languageMaterial == null)
            await throwBusinessException(LanguageMaterialsBusinessMessages.LanguageMaterialNotExists);
    }

    public async Task LanguageMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        LanguageMaterial? languageMaterial = await _languageMaterialRepository.GetAsync(
            predicate: lm => lm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LanguageMaterialShouldExistWhenSelected(languageMaterial);
    }
}