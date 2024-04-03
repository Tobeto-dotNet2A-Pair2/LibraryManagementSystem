using Application.Features.MemberContacts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MemberContacts.Rules;

public class MemberContactBusinessRules : BaseBusinessRules
{
    private readonly IMemberContactRepository _memberContactRepository;
    private readonly ILocalizationService _localizationService;

    public MemberContactBusinessRules(IMemberContactRepository memberContactRepository, ILocalizationService localizationService)
    {
        _memberContactRepository = memberContactRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MemberContactsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MemberContactShouldExistWhenSelected(MemberContact? memberContact)
    {
        if (memberContact == null)
            await throwBusinessException(MemberContactsBusinessMessages.MemberContactNotExists);
    }

    public async Task MemberContactIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MemberContact? memberContact = await _memberContactRepository.GetAsync(
            predicate: mc => mc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MemberContactShouldExistWhenSelected(memberContact);
    }
}