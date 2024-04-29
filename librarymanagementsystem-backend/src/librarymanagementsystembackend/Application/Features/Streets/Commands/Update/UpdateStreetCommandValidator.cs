using FluentValidation;

namespace Application.Features.Streets.Commands.Update;

public class UpdateStreetCommandValidator : AbstractValidator<UpdateStreetCommand>
{
    public UpdateStreetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 300);
        RuleFor(c => c.NeighborhoodId).NotEmpty();
    }
}