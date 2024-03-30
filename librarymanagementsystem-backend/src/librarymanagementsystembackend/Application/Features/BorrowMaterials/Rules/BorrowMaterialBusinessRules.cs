using Application.Features.BorrowMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BorrowMaterials.Rules;

public class BorrowMaterialBusinessRules : BaseBusinessRules
{
    private readonly IBorrowMaterialRepository _borrowMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public BorrowMaterialBusinessRules(IBorrowMaterialRepository borrowMaterialRepository, ILocalizationService localizationService)
    {
        _borrowMaterialRepository = borrowMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BorrowMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BorrowMaterialShouldExistWhenSelected(BorrowMaterial? borrowMaterial)
    {
        if (borrowMaterial == null)
            await throwBusinessException(BorrowMaterialsBusinessMessages.BorrowMaterialNotExists);
    }

    public async Task BorrowMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BorrowMaterial? borrowMaterial = await _borrowMaterialRepository.GetAsync(
            predicate: bm => bm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BorrowMaterialShouldExistWhenSelected(borrowMaterial);
    }
}