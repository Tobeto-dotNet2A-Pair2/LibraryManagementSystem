using FluentValidation;

namespace Application.Features.MaterialImages.Commands.Create;

public class CreateMaterialImageCommandValidator : AbstractValidator<CreateMaterialImageCommand>
{
    public CreateMaterialImageCommandValidator()
    {
        RuleFor(c => c.Image).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}