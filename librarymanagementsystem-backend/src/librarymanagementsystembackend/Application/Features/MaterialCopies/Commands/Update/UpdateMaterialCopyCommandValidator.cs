using FluentValidation;

namespace Application.Features.MaterialCopies.Commands.Update;

public class UpdateMaterialCopyCommandValidator : AbstractValidator<UpdateMaterialCopyCommand>
{
    public UpdateMaterialCopyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.DateReceipt).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.BorrowMaterialId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.LocationId).NotEmpty();
    }
}