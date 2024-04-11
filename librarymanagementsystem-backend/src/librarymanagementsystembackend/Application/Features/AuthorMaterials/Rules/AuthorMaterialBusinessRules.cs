using Application.Features.AuthorMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AuthorMaterials.Rules;

public class AuthorMaterialBusinessRules : BaseBusinessRules
{
    private readonly IAuthorMaterialRepository _authorMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorMaterialBusinessRules(IAuthorMaterialRepository authorMaterialRepository, ILocalizationService localizationService)
    {
        _authorMaterialRepository = authorMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorMaterialShouldExistWhenSelected(AuthorMaterial? authorMaterial)
    {
        if (authorMaterial == null)
            await throwBusinessException(AuthorMaterialsBusinessMessages.AuthorMaterialNotExists);
    }

    public async Task AuthorMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AuthorMaterial? authorMaterial = await _authorMaterialRepository.GetAsync(
            predicate: am => am.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorMaterialShouldExistWhenSelected(authorMaterial);
    }
}