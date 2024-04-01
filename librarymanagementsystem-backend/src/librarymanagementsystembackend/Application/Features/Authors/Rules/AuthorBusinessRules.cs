using Application.Features.Authors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Authors.Rules;

public class AuthorBusinessRules : BaseBusinessRules
{
    private readonly IAuthorRepository _authorRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorBusinessRules(IAuthorRepository authorRepository, ILocalizationService localizationService)
    {
        _authorRepository = authorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorShouldExistWhenSelected(Author? author)
    {
        if (author == null)
            await throwBusinessException(AuthorsBusinessMessages.AuthorNotExists);
    }

    public async Task AuthorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Author? author = await _authorRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorShouldExistWhenSelected(author);
    }
}