using FluentValidation;

namespace Application.Features.Translators.Commands.Update;

public class UpdateTranslatorCommandValidator : AbstractValidator<UpdateTranslatorCommand>
{
    public UpdateTranslatorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
        RuleFor(c => c.TranslatorName).NotEmpty().Length(1, 100);
        RuleFor(c => c.Description).NotEmpty().Length(1, 200);
    }
}