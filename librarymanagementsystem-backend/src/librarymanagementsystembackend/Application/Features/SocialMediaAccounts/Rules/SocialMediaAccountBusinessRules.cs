using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SocialMediaAccounts.Rules;

public class SocialMediaAccountBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
    private readonly ILocalizationService _localizationService;

    public SocialMediaAccountBusinessRules(ISocialMediaAccountRepository socialMediaAccountRepository, ILocalizationService localizationService)
    {
        _socialMediaAccountRepository = socialMediaAccountRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SocialMediaAccountsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SocialMediaAccountShouldExistWhenSelected(SocialMediaAccount? socialMediaAccount)
    {
        if (socialMediaAccount == null)
            await throwBusinessException(SocialMediaAccountsBusinessMessages.SocialMediaAccountNotExists);
    }

    public async Task SocialMediaAccountIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(
            predicate: sma => sma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);
    }
}