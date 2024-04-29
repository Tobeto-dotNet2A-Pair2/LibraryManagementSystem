using FluentValidation;

namespace Application.Features.Neighborhoods.Commands.Create;

public class CreateNeighborhoodCommandValidator : AbstractValidator<CreateNeighborhoodCommand>
{
    public CreateNeighborhoodCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(2, 150);
        RuleFor(c => c.DistrictId).NotEmpty();
    }
}