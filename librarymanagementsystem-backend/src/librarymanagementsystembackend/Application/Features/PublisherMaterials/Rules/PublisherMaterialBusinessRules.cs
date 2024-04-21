using Application.Features.PublisherMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PublisherMaterials.Rules;

public class PublisherMaterialBusinessRules : BaseBusinessRules
{
    private readonly IPublisherMaterialRepository _publisherMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public PublisherMaterialBusinessRules(IPublisherMaterialRepository publisherMaterialRepository, ILocalizationService localizationService)
    {
        _publisherMaterialRepository = publisherMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PublisherMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PublisherMaterialShouldExistWhenSelected(PublisherMaterial? publisherMaterial)
    {
        if (publisherMaterial == null)
            await throwBusinessException(PublisherMaterialsBusinessMessages.PublisherMaterialNotExists);
    }

    public async Task PublisherMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PublisherMaterial? publisherMaterial = await _publisherMaterialRepository.GetAsync(
            predicate: pm => pm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PublisherMaterialShouldExistWhenSelected(publisherMaterial);
    }
}