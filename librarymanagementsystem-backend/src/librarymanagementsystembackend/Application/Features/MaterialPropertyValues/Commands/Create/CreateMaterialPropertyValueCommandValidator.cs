using FluentValidation;

namespace Application.Features.MaterialPropertyValues.Commands.Create;

public class CreateMaterialPropertyValueCommandValidator : AbstractValidator<CreateMaterialPropertyValueCommand>
{
    public CreateMaterialPropertyValueCommandValidator()
    {
        RuleFor(c => c.Content).NotEmpty().Length(2, 150);
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.MaterialTypeId).NotEmpty();
        RuleFor(c => c.MaterialPropertyId).NotEmpty();
    }
}