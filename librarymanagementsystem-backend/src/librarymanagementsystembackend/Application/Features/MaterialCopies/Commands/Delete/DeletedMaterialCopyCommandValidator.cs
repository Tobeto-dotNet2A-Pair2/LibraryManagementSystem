using FluentValidation;

namespace Application.Features.MaterialCopies.Commands.Delete;

public class DeleteMaterialCopyCommandValidator : AbstractValidator<DeleteMaterialCopyCommand>
{
    public DeleteMaterialCopyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}