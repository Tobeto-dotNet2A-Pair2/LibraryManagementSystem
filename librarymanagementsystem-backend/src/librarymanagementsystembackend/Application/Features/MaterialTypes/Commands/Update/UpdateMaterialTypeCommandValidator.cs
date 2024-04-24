using FluentValidation;

namespace Application.Features.MaterialTypes.Commands.Update;

public class UpdateMaterialTypeCommandValidator : AbstractValidator<UpdateMaterialTypeCommand>
{
    public UpdateMaterialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MaterialFormat).NotEmpty();
    }
}