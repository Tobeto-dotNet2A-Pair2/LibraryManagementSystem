using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Update;

public class UpdateMaterialTypeCommandValidator : AbstractValidator<UpdateMaterialTypeCommand>
{
    public UpdateMaterialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); ;
        RuleFor(c => c.MaterialTypeName).NotEmpty().Length(1, 100);
        RuleFor(c => c.MaterialTypeCategory).NotEmpty();
    }
}