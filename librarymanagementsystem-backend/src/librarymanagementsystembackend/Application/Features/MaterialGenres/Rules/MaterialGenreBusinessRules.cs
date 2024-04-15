using Application.Features.MaterialGenres.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialGenres.Rules;

public class MaterialGenreBusinessRules : BaseBusinessRules
{
    private readonly IMaterialGenreRepository _materialGenreRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialGenreBusinessRules(IMaterialGenreRepository materialGenreRepository, ILocalizationService localizationService)
    {
        _materialGenreRepository = materialGenreRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialGenresBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialGenreShouldExistWhenSelected(MaterialGenre? materialGenre)
    {
        if (materialGenre == null)
            await throwBusinessException(MaterialGenresBusinessMessages.MaterialGenreNotExists);
    }

    public async Task MaterialGenreIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialGenre? materialGenre = await _materialGenreRepository.GetAsync(
            predicate: mg => mg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialGenreShouldExistWhenSelected(materialGenre);
    }
}