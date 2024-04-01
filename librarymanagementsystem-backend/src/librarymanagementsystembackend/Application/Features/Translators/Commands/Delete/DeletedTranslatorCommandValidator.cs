using FluentValidation;

namespace Application.Features.Translators.Commands.Delete;

public class DeleteTranslatorCommandValidator : AbstractValidator<DeleteTranslatorCommand>
{
    public DeleteTranslatorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}