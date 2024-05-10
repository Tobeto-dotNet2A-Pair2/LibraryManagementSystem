using FluentValidation;

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(1);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(400);
        RuleFor(c => c.PunishmentAmount).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.IsBorrowable);
        RuleFor(c => c.BorrowDay);
    }
}