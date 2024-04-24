using FluentValidation;

namespace Application.Features.MaterialImages.Commands.Delete;

public class DeleteMaterialImageCommandValidator : AbstractValidator<DeleteMaterialImageCommand>
{
    public DeleteMaterialImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}