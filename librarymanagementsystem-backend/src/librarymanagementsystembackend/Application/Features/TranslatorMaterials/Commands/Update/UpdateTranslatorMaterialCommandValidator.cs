using FluentValidation;

namespace Application.Features.TranslatorMaterials.Commands.Update;

public class UpdateTranslatorMaterialCommandValidator : AbstractValidator<UpdateTranslatorMaterialCommand>
{
    public UpdateTranslatorMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TranslatorId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}