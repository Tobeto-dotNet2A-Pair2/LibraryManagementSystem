using FluentValidation;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommandValidator : AbstractValidator<CreateTranslatorCommand>
{
    public CreateTranslatorCommandValidator()
    {
        RuleFor(c => c.TranslatorName).NotEmpty().Length(2,150);
        RuleFor(c => c.Description).NotEmpty().Length(2, 500);
    }
}