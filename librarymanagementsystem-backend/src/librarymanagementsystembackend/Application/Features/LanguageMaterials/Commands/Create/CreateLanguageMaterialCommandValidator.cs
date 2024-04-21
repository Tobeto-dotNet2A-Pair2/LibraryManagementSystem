using FluentValidation;

namespace Application.Features.LanguageMaterials.Commands.Create;

public class CreateLanguageMaterialCommandValidator : AbstractValidator<CreateLanguageMaterialCommand>
{
    public CreateLanguageMaterialCommandValidator()
    {
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}