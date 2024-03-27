using Application.Features.Cities.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Cities.Rules;

public class CityBusinessRules : BaseBusinessRules
{
    private readonly ICityRepository _cityRepository;
    private readonly ILocalizationService _localizationService;

    public CityBusinessRules(ICityRepository cityRepository, ILocalizationService localizationService)
    {
        _cityRepository = cityRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CitiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CityShouldExistWhenSelected(City? city)
    {
        if (city == null)
            await throwBusinessException(CitiesBusinessMessages.CityNotExists);
    }

    public async Task CityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        City? city = await _cityRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CityShouldExistWhenSelected(city);
    }
}