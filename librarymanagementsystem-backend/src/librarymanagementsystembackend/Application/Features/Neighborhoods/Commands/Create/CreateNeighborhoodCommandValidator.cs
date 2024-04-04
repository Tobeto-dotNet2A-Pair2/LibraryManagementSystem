using FluentValidation;

namespace Application.Features.Neighborhoods.Commands.Create;

public class CreateNeighborhoodCommandValidator : AbstractValidator<CreateNeighborhoodCommand>
{
    public CreateNeighborhoodCommandValidator()
    {
        RuleFor(c => c.NeighborhoodName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.DistrictId).NotEmpty();
    }
}