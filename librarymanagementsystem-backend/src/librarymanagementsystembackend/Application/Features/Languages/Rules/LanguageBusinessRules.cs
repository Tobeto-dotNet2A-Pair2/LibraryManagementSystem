using Application.Features.Languages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Languages.Rules;

public class LanguageBusinessRules : BaseBusinessRules
{
    private readonly ILanguageRepository _languageRepository;
    private readonly ILocalizationService _localizationService;

    public LanguageBusinessRules(ILanguageRepository languageRepository, ILocalizationService localizationService)
    {
        _languageRepository = languageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LanguagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LanguageShouldExistWhenSelected(Language? language)
    {
        if (language == null)
            await throwBusinessException(LanguagesBusinessMessages.LanguageNotExists);
    }

    public async Task LanguageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Language? language = await _languageRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LanguageShouldExistWhenSelected(language);
    }
}