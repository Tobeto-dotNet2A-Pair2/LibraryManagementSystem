using FluentValidation;

namespace Application.Features.MaterialCopies.Commands.Create;

public class CreateMaterialCopyCommandValidator : AbstractValidator<CreateMaterialCopyCommand>
{
    public CreateMaterialCopyCommandValidator()
    {
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.DateReceipt).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.BorrowMaterialId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.LocationId).NotEmpty();
    }
}