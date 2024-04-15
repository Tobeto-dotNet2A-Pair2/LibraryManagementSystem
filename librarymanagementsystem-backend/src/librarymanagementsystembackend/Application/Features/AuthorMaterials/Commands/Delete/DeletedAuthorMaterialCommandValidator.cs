using FluentValidation;

namespace Application.Features.AuthorMaterials.Commands.Delete;

public class DeleteAuthorMaterialCommandValidator : AbstractValidator<DeleteAuthorMaterialCommand>
{
    public DeleteAuthorMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}