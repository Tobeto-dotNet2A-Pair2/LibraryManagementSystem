using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Delete;

public class DeleteBorrowedMaterialCommandValidator : AbstractValidator<DeleteBorrowedMaterialCommand>
{
    public DeleteBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}