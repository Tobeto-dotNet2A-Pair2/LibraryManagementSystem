using FluentValidation;

namespace Application.Features.AuthorMaterials.Commands.Update;

public class UpdateAuthorMaterialCommandValidator : AbstractValidator<UpdateAuthorMaterialCommand>
{
    public UpdateAuthorMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}