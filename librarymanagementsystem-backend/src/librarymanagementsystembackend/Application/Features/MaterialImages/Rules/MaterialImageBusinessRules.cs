using Application.Features.MaterialImages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialImages.Rules;

public class MaterialImageBusinessRules : BaseBusinessRules
{
    private readonly IMaterialImageRepository _materialImageRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialImageBusinessRules(IMaterialImageRepository materialImageRepository, ILocalizationService localizationService)
    {
        _materialImageRepository = materialImageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialImageShouldExistWhenSelected(MaterialImage? materialImage)
    {
        if (materialImage == null)
            await throwBusinessException(MaterialImagesBusinessMessages.MaterialImageNotExists);
    }

    public async Task MaterialImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialImage? materialImage = await _materialImageRepository.GetAsync(
            predicate: mi => mi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialImageShouldExistWhenSelected(materialImage);
    }
}