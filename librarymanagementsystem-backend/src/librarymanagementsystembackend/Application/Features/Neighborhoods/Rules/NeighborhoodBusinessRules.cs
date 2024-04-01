using Application.Features.Neighborhoods.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Neighborhoods.Rules;

public class NeighborhoodBusinessRules : BaseBusinessRules
{
    private readonly INeighborhoodRepository _neighborhoodRepository;
    private readonly ILocalizationService _localizationService;

    public NeighborhoodBusinessRules(INeighborhoodRepository neighborhoodRepository, ILocalizationService localizationService)
    {
        _neighborhoodRepository = neighborhoodRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, NeighborhoodsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task NeighborhoodShouldExistWhenSelected(Neighborhood? neighborhood)
    {
        if (neighborhood == null)
            await throwBusinessException(NeighborhoodsBusinessMessages.NeighborhoodNotExists);
    }

    public async Task NeighborhoodIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Neighborhood? neighborhood = await _neighborhoodRepository.GetAsync(
            predicate: n => n.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await NeighborhoodShouldExistWhenSelected(neighborhood);
    }
}