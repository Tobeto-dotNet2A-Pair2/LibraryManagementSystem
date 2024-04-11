using FluentValidation;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommandValidator : AbstractValidator<CreateTranslatorCommand>
{
    public CreateTranslatorCommandValidator()
    {
        RuleFor(c => c.TranslatorName).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}