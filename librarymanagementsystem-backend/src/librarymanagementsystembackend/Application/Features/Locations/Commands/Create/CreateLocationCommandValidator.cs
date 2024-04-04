using FluentValidation;

namespace Application.Features.Locations.Commands.Create;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(c => c.ShelfLineNumber).MaximumLength(50);
        RuleFor(c => c.ShelfFloor).MaximumLength(50);
        RuleFor(c => c.Shelf).MaximumLength(50);
        RuleFor(c => c.Corridor).MaximumLength(50);
        RuleFor(c => c.Floor).MaximumLength(50);
        RuleFor(c => c.FullLocationMap).MaximumLength(50);
    }
}