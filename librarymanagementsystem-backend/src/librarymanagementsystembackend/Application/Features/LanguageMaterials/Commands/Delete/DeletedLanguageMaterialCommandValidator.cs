using FluentValidation;

namespace Application.Features.LanguageMaterials.Commands.Delete;

public class DeleteLanguageMaterialCommandValidator : AbstractValidator<DeleteLanguageMaterialCommand>
{
    public DeleteLanguageMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}