using FluentValidation;

namespace Application.Features.Districts.Commands.Create;

public class CreateDistrictCommandValidator : AbstractValidator<CreateDistrictCommand>
{
    public CreateDistrictCommandValidator()
    {
        RuleFor(c => c.DistrictName).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
    }
}