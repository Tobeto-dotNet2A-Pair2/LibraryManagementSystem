using Application.Features.MaterialTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialTypes.Rules;

public class MaterialTypeBusinessRules : BaseBusinessRules
{
    private readonly IMaterialTypeRepository _materialTypeRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialTypeBusinessRules(IMaterialTypeRepository materialTypeRepository, ILocalizationService localizationService)
    {
        _materialTypeRepository = materialTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialTypeShouldExistWhenSelected(MaterialType? materialType)
    {
        if (materialType == null)
            await throwBusinessException(MaterialTypesBusinessMessages.MaterialTypeNotExists);
    }

    public async Task MaterialTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialType? materialType = await _materialTypeRepository.GetAsync(
            predicate: mt => mt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialTypeShouldExistWhenSelected(materialType);
    }
}