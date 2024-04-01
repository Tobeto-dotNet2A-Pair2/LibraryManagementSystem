using FluentValidation;

namespace Application.Features.Locations.Commands.Create;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(c => c.ShelfLineNumber).NotEmpty();
        RuleFor(c => c.ShelfFloor).NotEmpty();
        RuleFor(c => c.Shelf).NotEmpty();
        RuleFor(c => c.Corridor).NotEmpty();
        RuleFor(c => c.Floor).NotEmpty();
        RuleFor(c => c.FullLocationMap).NotEmpty();
    }
}