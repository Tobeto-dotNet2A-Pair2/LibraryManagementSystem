using Application.Features.Materials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Materials.Rules;

public class MaterialBusinessRules : BaseBusinessRules
{
    private readonly IMaterialRepository _materialRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialBusinessRules(IMaterialRepository materialRepository, ILocalizationService localizationService)
    {
        _materialRepository = materialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialShouldExistWhenSelected(Material? material)
    {
        if (material == null)
            await throwBusinessException(MaterialsBusinessMessages.MaterialNotExists);
    }

    public async Task MaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialShouldExistWhenSelected(material);
    }
}