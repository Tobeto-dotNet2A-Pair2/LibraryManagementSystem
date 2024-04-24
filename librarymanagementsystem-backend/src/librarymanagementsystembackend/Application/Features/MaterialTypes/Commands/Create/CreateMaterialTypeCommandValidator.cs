using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Create;

public class CreateMaterialTypeCommandValidator : AbstractValidator<CreateMaterialTypeCommand>
{
    public CreateMaterialTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(2, 100);
        RuleFor(c => c.MaterialFormat).NotEmpty();
    }
}