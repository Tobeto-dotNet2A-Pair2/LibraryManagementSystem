using Application.Features.Locations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Locations.Rules;

public class LocationBusinessRules : BaseBusinessRules
{
    private readonly ILocationRepository _locationRepository;
    private readonly ILocalizationService _localizationService;

    public LocationBusinessRules(ILocationRepository locationRepository, ILocalizationService localizationService)
    {
        _locationRepository = locationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LocationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LocationShouldExistWhenSelected(Location? location)
    {
        if (location == null)
            await throwBusinessException(LocationsBusinessMessages.LocationNotExists);
    }

    public async Task LocationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Location? location = await _locationRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LocationShouldExistWhenSelected(location);
    }
}