using Application.Features.FavoriteListMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FavoriteListMaterials.Rules;

public class FavoriteListMaterialBusinessRules : BaseBusinessRules
{
    private readonly IFavoriteListMaterialRepository _favoriteListMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public FavoriteListMaterialBusinessRules(IFavoriteListMaterialRepository favoriteListMaterialRepository, ILocalizationService localizationService)
    {
        _favoriteListMaterialRepository = favoriteListMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FavoriteListMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FavoriteListMaterialShouldExistWhenSelected(FavoriteListMaterial? favoriteListMaterial)
    {
        if (favoriteListMaterial == null)
            await throwBusinessException(FavoriteListMaterialsBusinessMessages.FavoriteListMaterialNotExists);
    }

    public async Task FavoriteListMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FavoriteListMaterial? favoriteListMaterial = await _favoriteListMaterialRepository.GetAsync(
            predicate: flm => flm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FavoriteListMaterialShouldExistWhenSelected(favoriteListMaterial);
    }
}