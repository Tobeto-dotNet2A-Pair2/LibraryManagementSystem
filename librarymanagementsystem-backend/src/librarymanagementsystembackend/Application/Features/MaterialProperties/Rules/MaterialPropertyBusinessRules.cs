using Application.Features.MaterialProperties.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialProperties.Rules;

public class MaterialPropertyBusinessRules : BaseBusinessRules
{
    private readonly IMaterialPropertyRepository _materialPropertyRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialPropertyBusinessRules(IMaterialPropertyRepository materialPropertyRepository, ILocalizationService localizationService)
    {
        _materialPropertyRepository = materialPropertyRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialPropertiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialPropertyShouldExistWhenSelected(MaterialProperty? materialProperty)
    {
        if (materialProperty == null)
            await throwBusinessException(MaterialPropertiesBusinessMessages.MaterialPropertyNotExists);
    }

    public async Task MaterialPropertyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialProperty? materialProperty = await _materialPropertyRepository.GetAsync(
            predicate: mp => mp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialPropertyShouldExistWhenSelected(materialProperty);
    }
}