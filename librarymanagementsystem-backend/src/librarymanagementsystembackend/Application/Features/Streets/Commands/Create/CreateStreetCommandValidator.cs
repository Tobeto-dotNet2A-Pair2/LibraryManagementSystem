using FluentValidation;

namespace Application.Features.Streets.Commands.Create;

public class CreateStreetCommandValidator : AbstractValidator<CreateStreetCommand>
{
    public CreateStreetCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(2, 300);
        RuleFor(c => c.NeighborhoodId).NotEmpty();
    }
}