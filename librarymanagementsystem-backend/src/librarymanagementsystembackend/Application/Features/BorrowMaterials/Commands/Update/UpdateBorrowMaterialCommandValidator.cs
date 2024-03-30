using FluentValidation;

namespace Application.Features.BorrowMaterials.Commands.Update;

public class UpdateBorrowMaterialCommandValidator : AbstractValidator<UpdateBorrowMaterialCommand>
{
    public UpdateBorrowMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BorrowDate).NotEmpty();
        RuleFor(c => c.ReturnDate).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}