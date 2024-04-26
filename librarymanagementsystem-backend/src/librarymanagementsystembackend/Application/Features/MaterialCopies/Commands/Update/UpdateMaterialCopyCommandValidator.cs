using FluentValidation;

namespace Application.Features.MaterialCopies.Commands.Update;

public class UpdateMaterialCopyCommandValidator : AbstractValidator<UpdateMaterialCopyCommand>
{
    public UpdateMaterialCopyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DateReceipt).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date); 
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.IsReserved).NotEmpty();
        RuleFor(c => c.IsReservable).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.LocationId).NotEmpty();
    }
}