using Application.Features.BorrowedMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BorrowedMaterials.Rules;

public class BorrowedMaterialBusinessRules : BaseBusinessRules
{
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public BorrowedMaterialBusinessRules(IBorrowedMaterialRepository borrowedMaterialRepository, ILocalizationService localizationService)
    {
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BorrowedMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BorrowedMaterialShouldExistWhenSelected(BorrowedMaterial? borrowedMaterial)
    {
        if (borrowedMaterial == null)
            await throwBusinessException(BorrowedMaterialsBusinessMessages.BorrowedMaterialNotExists);
    }

    public async Task BorrowedMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(
            predicate: bm => bm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BorrowedMaterialShouldExistWhenSelected(borrowedMaterial);
    }
}