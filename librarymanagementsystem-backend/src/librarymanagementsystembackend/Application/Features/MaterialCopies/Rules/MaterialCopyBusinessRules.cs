using Application.Features.MaterialCopies.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialCopies.Rules;

public class MaterialCopyBusinessRules : BaseBusinessRules
{
    private readonly IMaterialCopyRepository _materialCopyRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialCopyBusinessRules(IMaterialCopyRepository materialCopyRepository, ILocalizationService localizationService)
    {
        _materialCopyRepository = materialCopyRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialCopiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialCopyShouldExistWhenSelected(MaterialCopy? materialCopy)
    {
        if (materialCopy == null)
            await throwBusinessException(MaterialCopiesBusinessMessages.MaterialCopyNotExists);
    }

    public async Task MaterialCopyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialCopy? materialCopy = await _materialCopyRepository.GetAsync(
            predicate: mc => mc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialCopyShouldExistWhenSelected(materialCopy);
    }
}