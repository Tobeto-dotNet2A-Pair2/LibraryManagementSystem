using FluentValidation;

namespace Application.Features.MaterialProperties.Commands.Create;

public class CreateMaterialPropertyCommandValidator : AbstractValidator<CreateMaterialPropertyCommand>
{
    public CreateMaterialPropertyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(2, 150);
    }
}