using FluentValidation;

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(1);

        RuleFor(c => c.Description).MaximumLength(400)
            .When(c => !string.IsNullOrEmpty(c.Description));

        RuleFor(c => c.PublicationDate).NotEmpty().GreaterThan(DateTime.MinValue.Date)
            .LessThanOrEqualTo(DateTime.Now.Date);

        RuleFor(c => c.PunishmentAmount).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.IsBorrowable).NotEmpty();
        RuleFor(c => c.BorrowDay).Must((c, borrowDay) => !c.IsBorrowable || borrowDay > 0);
    }
}