using Application.Features.Members.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Application.Features.Members.Rules;

public class MemberBusinessRules : BaseBusinessRules
{
    private readonly IMemberRepository _memberRepository;
    private readonly ILocalizationService _localizationService;

    public MemberBusinessRules(IMemberRepository memberRepository, ILocalizationService localizationService)
    {
        _memberRepository = memberRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MembersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MemberShouldExistWhenSelected(Member? member)
    {
        if (member == null)
            await throwBusinessException(MembersBusinessMessages.MemberNotExists);
    }

    public async Task MemberIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Member? member = await _memberRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MemberShouldExistWhenSelected(member);
    }

    public async Task MemberShouldHaveNoDebt(Guid id, CancellationToken cancellationToken)
    {
        decimal totalDebt = await _memberRepository.Query()
            .Where(a => a.Id == id)
            .Select(a => a.TotalDebt)
            .FirstOrDefaultAsync(cancellationToken);
         
        if(totalDebt > 0)
            await throwBusinessException(MembersBusinessMessages.MemberHaveDebt);
    }
}