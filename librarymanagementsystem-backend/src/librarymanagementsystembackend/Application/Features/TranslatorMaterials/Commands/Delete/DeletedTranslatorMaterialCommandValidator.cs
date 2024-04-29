using FluentValidation;

namespace Application.Features.TranslatorMaterials.Commands.Delete;

public class DeleteTranslatorMaterialCommandValidator : AbstractValidator<DeleteTranslatorMaterialCommand>
{
    public DeleteTranslatorMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}