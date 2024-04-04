using FluentValidation;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommandValidator : AbstractValidator<CreateTranslatorCommand>
{
    public CreateTranslatorCommandValidator()
    {
        RuleFor(c => c.TranslatorName).NotEmpty().Length(1,100);
        RuleFor(c => c.Description).NotEmpty().Length(1, 200);
    }
}