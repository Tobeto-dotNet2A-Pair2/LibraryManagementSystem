using FluentValidation;

namespace Application.Features.Neighborhoods.Commands.Update;

public class UpdateNeighborhoodCommandValidator : AbstractValidator<UpdateNeighborhoodCommand>
{
    public UpdateNeighborhoodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.NeighborhoodName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.DistrictId).NotEmpty();
    }
}