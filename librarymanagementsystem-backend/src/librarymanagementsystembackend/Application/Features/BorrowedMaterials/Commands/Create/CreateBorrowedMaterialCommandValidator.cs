using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommandValidator : AbstractValidator<CreateBorrowedMaterialCommand>
{
    public CreateBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.BorrowDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
        RuleFor(c => c.ReturnDate).NotEmpty().GreaterThan(c => c.BorrowDate);
        RuleFor(c => c.IsReturned).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.MaterialCopyId).NotEmpty();
    }
}