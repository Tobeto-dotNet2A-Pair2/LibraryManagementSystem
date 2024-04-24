using FluentValidation;

namespace Application.Features.Locations.Commands.Update;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ShelfLineNumber).Length(2, 50);
        RuleFor(c => c.ShelfFloor).Length(2, 50);
        RuleFor(c => c.Shelf).Length(2, 50);
        RuleFor(c => c.Corridor).Length(2, 50);
        RuleFor(c => c.Floor).Length(2, 50);
        RuleFor(c => c.FullLocationMap).Length(2, 50);
    }
}