using FluentValidation;

namespace Application.Features.MaterialPropertyValues.Commands.Delete;

public class DeleteMaterialPropertyValueCommandValidator : AbstractValidator<DeleteMaterialPropertyValueCommand>
{
    public DeleteMaterialPropertyValueCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}