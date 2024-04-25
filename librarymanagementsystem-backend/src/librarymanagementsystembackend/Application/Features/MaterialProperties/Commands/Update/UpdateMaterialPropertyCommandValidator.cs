using FluentValidation;

namespace Application.Features.MaterialProperties.Commands.Update;

public class UpdateMaterialPropertyCommandValidator : AbstractValidator<UpdateMaterialPropertyCommand>
{
    public UpdateMaterialPropertyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 150);
    }
}