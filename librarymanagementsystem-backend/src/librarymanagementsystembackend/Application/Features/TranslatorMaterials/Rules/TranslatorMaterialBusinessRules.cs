using Application.Features.TranslatorMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TranslatorMaterials.Rules;

public class TranslatorMaterialBusinessRules : BaseBusinessRules
{
    private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public TranslatorMaterialBusinessRules(ITranslatorMaterialRepository translatorMaterialRepository, ILocalizationService localizationService)
    {
        _translatorMaterialRepository = translatorMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TranslatorMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TranslatorMaterialShouldExistWhenSelected(TranslatorMaterial? translatorMaterial)
    {
        if (translatorMaterial == null)
            await throwBusinessException(TranslatorMaterialsBusinessMessages.TranslatorMaterialNotExists);
    }

    public async Task TranslatorMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TranslatorMaterial? translatorMaterial = await _translatorMaterialRepository.GetAsync(
            predicate: tm => tm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TranslatorMaterialShouldExistWhenSelected(translatorMaterial);
    }
}