using FluentValidation;

namespace Application.Features.MaterialProperties.Commands.Update;

public class UpdateMaterialPropertyCommandValidator : AbstractValidator<UpdateMaterialPropertyCommand>
{
    public UpdateMaterialPropertyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialPropertyName).NotEmpty().MinimumLength(2).MaximumLength(150);
    }
}