using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdateBorrowedMaterialCommandValidator : AbstractValidator<UpdateBorrowedMaterialCommand>
{
    public UpdateBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BorrowedDate).NotEmpty();
        RuleFor(c => c.ReturnDate).NotEmpty();
        RuleFor(c => c.IsReturned).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.MaterialCopyId).NotEmpty();
    }
}