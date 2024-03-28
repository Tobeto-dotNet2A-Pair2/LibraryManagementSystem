using FluentValidation;

namespace Application.Features.Locations.Commands.Update;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ShelfLineNumber).NotEmpty();
        RuleFor(c => c.ShelfFloor).NotEmpty();
        RuleFor(c => c.Shelf).NotEmpty();
        RuleFor(c => c.Corridor).NotEmpty();
        RuleFor(c => c.Floor).NotEmpty();
    }
}