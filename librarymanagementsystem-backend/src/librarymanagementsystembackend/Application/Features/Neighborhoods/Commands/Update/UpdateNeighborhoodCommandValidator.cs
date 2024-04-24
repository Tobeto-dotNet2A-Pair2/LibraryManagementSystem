using FluentValidation;

namespace Application.Features.Neighborhoods.Commands.Update;

public class UpdateNeighborhoodCommandValidator : AbstractValidator<UpdateNeighborhoodCommand>
{
    public UpdateNeighborhoodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
    }
}