using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Create;

public class CreateMaterialTypeCommandValidator : AbstractValidator<CreateMaterialTypeCommand>
{
    public CreateMaterialTypeCommandValidator()
    {
        RuleFor(c => c.MaterialTypeName).NotEmpty().Length(1,100);
        RuleFor(c => c.MaterialTypeCategory).NotEmpty();
    }
}