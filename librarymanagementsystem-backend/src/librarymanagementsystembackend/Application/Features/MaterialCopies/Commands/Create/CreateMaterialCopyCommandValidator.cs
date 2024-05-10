using FluentValidation;

namespace Application.Features.MaterialCopies.Commands.Create;

public class CreateMaterialCopyCommandValidator : AbstractValidator<CreateMaterialCopyCommand>
{
    public CreateMaterialCopyCommandValidator()
    {
        RuleFor(c => c.DateReceipt).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.IsReserved);
        RuleFor(c => c.IsReservable);
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.LocationId).NotEmpty();
    }
}