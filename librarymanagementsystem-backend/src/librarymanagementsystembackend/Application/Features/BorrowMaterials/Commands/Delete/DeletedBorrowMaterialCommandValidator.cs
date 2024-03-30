using FluentValidation;

namespace Application.Features.BorrowMaterials.Commands.Delete;

public class DeleteBorrowMaterialCommandValidator : AbstractValidator<DeleteBorrowMaterialCommand>
{
    public DeleteBorrowMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}