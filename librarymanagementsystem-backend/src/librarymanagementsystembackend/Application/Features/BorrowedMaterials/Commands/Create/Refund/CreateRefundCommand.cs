using Application.Features.BorrowedMaterials.Rules;
using Application.Features.Penalties.Dto;
using Application.Services.MaterialCopies;
using Application.Services.Penalties;
using Application.Services.Repositories;
using MediatR;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.BorrowedMaterials.Commands.Create.Refund;

public class CreateRefundCommand : IRequest<CreateRefundResponse>
{
    public Guid MemberId { get; set; }
    public Guid MaterialCopyId { get; set; }
    
    public class CreateRefundHandler : IRequestHandler<CreateRefundCommand,CreateRefundResponse>
    {
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly IPenaltyService _penaltyService;
        private readonly IMaterialCopyService _materialCopyService;
        
        public CreateRefundHandler(BorrowedMaterialBusinessRules borrowedMaterialBusinessRules, 
            IBorrowedMaterialRepository borrowedMaterialRepository, 
            IPenaltyService penaltyService, 
            IMaterialCopyService materialCopyService)
        {
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _penaltyService = penaltyService;
            _materialCopyService = materialCopyService;
        }
        
        public async Task<CreateRefundResponse> Handle(CreateRefundCommand request, CancellationToken cancellationToken)
        {
            #region BusinessRules
            await _borrowedMaterialBusinessRules.MemberHasActiveBorrowSelectedMaterialCopy(request.MemberId, request.MaterialCopyId, cancellationToken);
            
            #endregion
            
            #region Prepare Data
            var borrowedMaterial = await _borrowedMaterialRepository.GetAsync(a => a.MemberId == request.MemberId &&
                a.MaterialCopyId == request.MaterialCopyId && 
                !a.IsReturned, cancellationToken: cancellationToken);
            
            var borrowedMaterialTotalValues = await _borrowedMaterialRepository.GetMemberDeptForBorrowedMaterialCopyAsync(request.MemberId,
                    request.MaterialCopyId, cancellationToken);
            
            #endregion
            
            #region Penalty
            
            if(borrowedMaterialTotalValues.TotalDebt > 0)
            {
                var createPenalty = new CreatePenaltyWhenRefundDto()
                {
                    BorrowedMaterialId = borrowedMaterial!.Id,
                    TotalMaterialDebt = borrowedMaterialTotalValues.TotalDebt,
                    DayDelay = borrowedMaterialTotalValues.DelayDay
                };
                await _penaltyService.CreateWhenRefund(createPenalty);
            }
            
            #endregion
            
            #region Refund Operations

            borrowedMaterial!.IsReturned = true;
            //This date will be expected refund date. 
            borrowedMaterial.UpdatedDate = DateTime.UtcNow;
            await _borrowedMaterialRepository.UpdateAsync(borrowedMaterial);
            
            // Update isReserved and isReservable fields in material copy. 

            await _materialCopyService.UpdateAfterRefund(request.MaterialCopyId);

            #endregion

            return new CreateRefundResponse();
        }
    }
}