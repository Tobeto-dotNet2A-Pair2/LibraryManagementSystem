using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(1);

        RuleFor(c => c.Description).MaximumLength(400)
            .When(c => !string.IsNullOrEmpty(c.Description));

        RuleFor(c => c.PublicationDate).NotEmpty().GreaterThan(DateTime.MinValue.Date)
            .LessThanOrEqualTo(DateTime.Now.Date);

        RuleFor(c => c.PunishmentAmount).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.IsBorrowable).Must(value => value == true || value == false);
        RuleFor(c => c.BorrowDay).Must((c, borrowDay) => !c.IsBorrowable || borrowDay > 0);
    }
}