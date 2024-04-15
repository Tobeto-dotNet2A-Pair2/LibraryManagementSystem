using FluentValidation;

namespace Application.Features.Cities.Commands.Update;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CityName).NotEmpty().Length(2, 50).Matches("^[a-zA-Z?ü?öç?Ü??ÖÇ]+$");
    }
}