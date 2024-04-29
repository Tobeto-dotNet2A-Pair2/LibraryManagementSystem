using Application.Features.MemberAddresses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MemberAddresses.Rules;

public class MemberAddressBusinessRules : BaseBusinessRules
{
    private readonly IMemberAddressRepository _memberAddressRepository;
    private readonly ILocalizationService _localizationService;

    public MemberAddressBusinessRules(IMemberAddressRepository memberAddressRepository, ILocalizationService localizationService)
    {
        _memberAddressRepository = memberAddressRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MemberAddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MemberAddressShouldExistWhenSelected(MemberAddress? memberAddress)
    {
        if (memberAddress == null)
            await throwBusinessException(MemberAddressesBusinessMessages.MemberAddressNotExists);
    }

    public async Task MemberAddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MemberAddress? memberAddress = await _memberAddressRepository.GetAsync(
            predicate: ma => ma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MemberAddressShouldExistWhenSelected(memberAddress);
    }
}