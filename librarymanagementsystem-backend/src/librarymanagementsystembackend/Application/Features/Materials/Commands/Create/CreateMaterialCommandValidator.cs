using FluentValidation;

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.PublicationDate).NotEmpty();
        RuleFor(c => c.Punishment).NotEmpty();
        RuleFor(c => c.IsBorrowable).NotEmpty();
        RuleFor(c => c.BorrowDay).NotEmpty();
    }
}