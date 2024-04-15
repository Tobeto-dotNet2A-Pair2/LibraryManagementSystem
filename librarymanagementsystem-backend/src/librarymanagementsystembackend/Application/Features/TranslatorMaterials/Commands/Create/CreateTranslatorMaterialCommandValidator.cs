using FluentValidation;

namespace Application.Features.TranslatorMaterials.Commands.Create;

public class CreateTranslatorMaterialCommandValidator : AbstractValidator<CreateTranslatorMaterialCommand>
{
    public CreateTranslatorMaterialCommandValidator()
    {
        RuleFor(c => c.TranslatorId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}