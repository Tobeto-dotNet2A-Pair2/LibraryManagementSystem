using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdateBorrowedMaterialCommandValidator : AbstractValidator<UpdateBorrowedMaterialCommand>
{
    public UpdateBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BorrowDate).NotEmpty();
        RuleFor(c => c.ReturnDate).NotEmpty();
    }
}