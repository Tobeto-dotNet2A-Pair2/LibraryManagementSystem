using Application.Features.Translators.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Translators.Rules;

public class TranslatorBusinessRules : BaseBusinessRules
{
    private readonly ITranslatorRepository _translatorRepository;
    private readonly ILocalizationService _localizationService;

    public TranslatorBusinessRules(ITranslatorRepository translatorRepository, ILocalizationService localizationService)
    {
        _translatorRepository = translatorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TranslatorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TranslatorShouldExistWhenSelected(Translator? translator)
    {
        if (translator == null)
            await throwBusinessException(TranslatorsBusinessMessages.TranslatorNotExists);
    }

    public async Task TranslatorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Translator? translator = await _translatorRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TranslatorShouldExistWhenSelected(translator);
    }
}