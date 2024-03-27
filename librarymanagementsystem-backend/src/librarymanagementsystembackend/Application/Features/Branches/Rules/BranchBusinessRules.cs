using Application.Features.Branches.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Branches.Rules;

public class BranchBusinessRules : BaseBusinessRules
{
    private readonly IBranchRepository _branchRepository;
    private readonly ILocalizationService _localizationService;

    public BranchBusinessRules(IBranchRepository branchRepository, ILocalizationService localizationService)
    {
        _branchRepository = branchRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BranchesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BranchShouldExistWhenSelected(Branch? branch)
    {
        if (branch == null)
            await throwBusinessException(BranchesBusinessMessages.BranchNotExists);
    }

    public async Task BranchIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Branch? branch = await _branchRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BranchShouldExistWhenSelected(branch);
    }
}