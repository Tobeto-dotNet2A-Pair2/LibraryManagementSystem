using Application.Features.BorrowedMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System.Linq.Dynamic.Core;

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
    public async Task MemberDoesNotHaveSameMaterialAtTheSameTime(Guid memberId, Guid materialCopyId, CancellationToken cancellationToken)
    {
         bool memberHasMaterialCopyAlready = await _borrowedMaterialRepository.AnyAsync(
            a => a.MemberId == memberId &&
                 a.MaterialCopyId == materialCopyId &&
                 !a.IsReturned, cancellationToken: cancellationToken);

         if (memberHasMaterialCopyAlready)
             await throwBusinessException(BorrowedMaterialsBusinessMessages.MemberAlreadyHaveThisMaterialCopy);
    }

    public async Task MemberHasActiveBorrowSelectedMaterialCopy(Guid memberId, Guid materialCopyId,
        CancellationToken cancellationToken)
    {
        bool memberHasSelectedMaterialCopy = await _borrowedMaterialRepository.Query()
            .AnyAsync(a => !a.IsReturned &&
                        a.MaterialCopyId == materialCopyId &&
                        a.MemberId == memberId, cancellationToken);
        
        if(!memberHasSelectedMaterialCopy)
            await throwBusinessException(BorrowedMaterialsBusinessMessages.MemberHasNotThisMaterialCopy);
        
    }
}