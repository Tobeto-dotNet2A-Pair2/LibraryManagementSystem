using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Create;

public class CreateMaterialTypeCommandValidator : AbstractValidator<CreateMaterialTypeCommand>
{
    public CreateMaterialTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MaterialFormat).NotEmpty();
    }
}