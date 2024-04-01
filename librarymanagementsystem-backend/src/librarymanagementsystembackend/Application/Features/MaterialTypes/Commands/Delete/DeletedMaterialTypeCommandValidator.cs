using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Delete;

public class DeleteMaterialTypeCommandValidator : AbstractValidator<DeleteMaterialTypeCommand>
{
    public DeleteMaterialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}