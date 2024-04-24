using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Update;

public class UpdateMaterialTypeCommandValidator : AbstractValidator<UpdateMaterialTypeCommand>
{
    public UpdateMaterialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 100);
        RuleFor(c => c.MaterialFormat).NotEmpty();
    }
}