using Application.Features.FavoriteLists.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FavoriteLists.Rules;

public class FavoriteListBusinessRules : BaseBusinessRules
{
    private readonly IFavoriteListRepository _favoriteListRepository;
    private readonly ILocalizationService _localizationService;

    public FavoriteListBusinessRules(IFavoriteListRepository favoriteListRepository, ILocalizationService localizationService)
    {
        _favoriteListRepository = favoriteListRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FavoriteListsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FavoriteListShouldExistWhenSelected(FavoriteList? favoriteList)
    {
        if (favoriteList == null)
            await throwBusinessException(FavoriteListsBusinessMessages.FavoriteListNotExists);
    }

    public async Task FavoriteListIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FavoriteList? favoriteList = await _favoriteListRepository.GetAsync(
            predicate: fl => fl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FavoriteListShouldExistWhenSelected(favoriteList);
    }
}