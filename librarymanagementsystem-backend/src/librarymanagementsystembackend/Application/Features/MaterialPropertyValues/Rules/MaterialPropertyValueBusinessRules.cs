using Application.Features.MaterialPropertyValues.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialPropertyValues.Rules;

public class MaterialPropertyValueBusinessRules : BaseBusinessRules
{
    private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialPropertyValueBusinessRules(IMaterialPropertyValueRepository materialPropertyValueRepository, ILocalizationService localizationService)
    {
        _materialPropertyValueRepository = materialPropertyValueRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialPropertyValuesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialPropertyValueShouldExistWhenSelected(MaterialPropertyValue? materialPropertyValue)
    {
        if (materialPropertyValue == null)
            await throwBusinessException(MaterialPropertyValuesBusinessMessages.MaterialPropertyValueNotExists);
    }

    public async Task MaterialPropertyValueIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialPropertyValue? materialPropertyValue = await _materialPropertyValueRepository.GetAsync(
            predicate: mpv => mpv.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialPropertyValueShouldExistWhenSelected(materialPropertyValue);
    }
}