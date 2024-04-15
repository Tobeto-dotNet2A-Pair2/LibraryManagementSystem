using FluentValidation;

namespace Application.Features.Streets.Commands.Create;

public class CreateStreetCommandValidator : AbstractValidator<CreateStreetCommand>
{
    public CreateStreetCommandValidator()
    {
        RuleFor(c => c.StreetName).NotEmpty().Length(2, 100).Matches("^[a-zA-Z?�?��?�??�� ]+$");
        RuleFor(c => c.NeighborhoodId).NotEmpty();
    }
}