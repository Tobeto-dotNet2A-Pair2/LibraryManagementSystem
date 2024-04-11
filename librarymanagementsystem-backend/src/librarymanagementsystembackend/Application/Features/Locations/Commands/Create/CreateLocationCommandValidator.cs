using FluentValidation;

namespace Application.Features.Locations.Commands.Create;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(c => c.ShelfLineNumber).Length(2, 50);
        RuleFor(c => c.ShelfFloor).Length(2, 50);
        RuleFor(c => c.Shelf).Length(2, 50);
        RuleFor(c => c.Corridor).Length(2, 50);
        RuleFor(c => c.Floor).Length(2, 50);
        RuleFor(c => c.FullLocationMap).Length(2,50);
    }
}