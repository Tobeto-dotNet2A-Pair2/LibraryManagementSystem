using Application.Features.Publishers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Publishers.Rules;

public class PublisherBusinessRules : BaseBusinessRules
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly ILocalizationService _localizationService;

    public PublisherBusinessRules(IPublisherRepository publisherRepository, ILocalizationService localizationService)
    {
        _publisherRepository = publisherRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PublishersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PublisherShouldExistWhenSelected(Publisher? publisher)
    {
        if (publisher == null)
            await throwBusinessException(PublishersBusinessMessages.PublisherNotExists);
    }

    public async Task PublisherIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Publisher? publisher = await _publisherRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PublisherShouldExistWhenSelected(publisher);
    }
}