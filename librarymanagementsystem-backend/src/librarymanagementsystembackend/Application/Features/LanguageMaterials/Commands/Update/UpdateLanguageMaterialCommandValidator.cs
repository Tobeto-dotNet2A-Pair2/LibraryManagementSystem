using FluentValidation;

namespace Application.Features.LanguageMaterials.Commands.Update;

public class UpdateLanguageMaterialCommandValidator : AbstractValidator<UpdateLanguageMaterialCommand>
{
    public UpdateLanguageMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}