using FluentValidation;

namespace Application.Features.AuthorMaterials.Commands.Create;

public class CreateAuthorMaterialCommandValidator : AbstractValidator<CreateAuthorMaterialCommand>
{
    public CreateAuthorMaterialCommandValidator()
    {
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}