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
    private readonly IBranchRepository _branchRepository;

    public SocialMediaAccountBusinessRules(ISocialMediaAccountRepository socialMediaAccountRepository, ILocalizationService localizationService, IBranchRepository branchRepository)
    {
        _socialMediaAccountRepository = socialMediaAccountRepository;
        _localizationService = localizationService;
        _branchRepository = branchRepository;
    }

    public async Task BranchIdIsExist(Guid branchId)
    {
        bool response = await _branchRepository.AnyAsync(b => b.Id == branchId);
        if (!response)
            await throwBusinessException(SocialMediaAccountsBusinessMessages.SocialMediaAccountBranchIdNotExist);
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