using FluentValidation;

namespace Application.Features.MaterialImages.Commands.Update;

public class UpdateMaterialImageCommandValidator : AbstractValidator<UpdateMaterialImageCommand>
{
    public UpdateMaterialImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}