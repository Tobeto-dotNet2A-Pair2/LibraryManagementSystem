using FluentValidation;

namespace Application.Features.Districts.Commands.Update;

public class UpdateDistrictCommandValidator : AbstractValidator<UpdateDistrictCommand>
{
    public UpdateDistrictCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 150);
        RuleFor(c => c.CityId).NotEmpty();
    }
}