using FluentValidation;

namespace Application.Features.MaterialProperties.Commands.Create;

public class CreateMaterialPropertyCommandValidator : AbstractValidator<CreateMaterialPropertyCommand>
{
    public CreateMaterialPropertyCommandValidator()
    {
        RuleFor(c => c.MaterialPropertyName).NotEmpty().MinimumLength(2).MaximumLength(150);
    }
}