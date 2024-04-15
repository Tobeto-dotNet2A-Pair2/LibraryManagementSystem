using FluentValidation;

namespace Application.Features.Translators.Commands.Update;

public class UpdateTranslatorCommandValidator : AbstractValidator<UpdateTranslatorCommand>
{
    public UpdateTranslatorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TranslatorName).NotEmpty().Length(2, 150);
        RuleFor(c => c.Description).NotEmpty().Length(2, 500);
    }
}