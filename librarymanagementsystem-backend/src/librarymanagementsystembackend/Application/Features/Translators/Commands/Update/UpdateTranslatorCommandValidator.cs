using FluentValidation;

namespace Application.Features.Translators.Commands.Update;

public class UpdateTranslatorCommandValidator : AbstractValidator<UpdateTranslatorCommand>
{
    public UpdateTranslatorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}