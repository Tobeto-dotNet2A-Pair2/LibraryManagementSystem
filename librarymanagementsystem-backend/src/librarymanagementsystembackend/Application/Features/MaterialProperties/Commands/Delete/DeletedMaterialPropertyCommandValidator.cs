using FluentValidation;

namespace Application.Features.MaterialProperties.Commands.Delete;

public class DeleteMaterialPropertyCommandValidator : AbstractValidator<DeleteMaterialPropertyCommand>
{
    public DeleteMaterialPropertyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}