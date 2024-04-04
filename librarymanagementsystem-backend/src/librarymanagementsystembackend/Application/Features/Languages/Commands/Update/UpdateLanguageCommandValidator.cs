using FluentValidation;

namespace Application.Features.Languages.Commands.Update;

public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
{
    public UpdateLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LanguageName).NotEmpty().MinimumLength(2).MaximumLength(150);
    }
}