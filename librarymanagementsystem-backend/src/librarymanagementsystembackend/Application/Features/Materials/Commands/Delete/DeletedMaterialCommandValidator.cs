using FluentValidation;

namespace Application.Features.Materials.Commands.Delete;

public class DeleteMaterialCommandValidator : AbstractValidator<DeleteMaterialCommand>
{
    public DeleteMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}