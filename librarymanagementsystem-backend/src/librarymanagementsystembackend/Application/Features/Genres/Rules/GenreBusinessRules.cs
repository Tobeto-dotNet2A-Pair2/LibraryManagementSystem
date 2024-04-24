using Application.Features.Genres.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Genres.Rules;

public class GenreBusinessRules : BaseBusinessRules
{
    private readonly IGenreRepository _genreRepository;
    private readonly ILocalizationService _localizationService;

    public GenreBusinessRules(IGenreRepository genreRepository, ILocalizationService localizationService)
    {
        _genreRepository = genreRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GenresBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GenreShouldExistWhenSelected(Genre? genre)
    {
        if (genre == null)
            await throwBusinessException(GenresBusinessMessages.GenreNotExists);
    }

    public async Task GenreIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Genre? genre = await _genreRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GenreShouldExistWhenSelected(genre);
    }
}