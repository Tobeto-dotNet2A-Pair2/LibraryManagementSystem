using FluentValidation;

namespace Application.Features.BorrowMaterials.Commands.Create;

public class CreateBorrowMaterialCommandValidator : AbstractValidator<CreateBorrowMaterialCommand>
{
    public CreateBorrowMaterialCommandValidator()
    {
        RuleFor(c => c.BorrowDate).NotEmpty();
        RuleFor(c => c.ReturnDate).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}