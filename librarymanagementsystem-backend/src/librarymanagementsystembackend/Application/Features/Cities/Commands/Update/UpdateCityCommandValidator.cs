using FluentValidation;

namespace Application.Features.Cities.Commands.Update;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
        //.WithMessage("ID alaný geçersiz bir GUID formatýna sahip.");
        RuleFor(c => c.CityName).NotEmpty().Length(2, 50).Matches("^[a-zA-ZðüþöçÐÜÞÝÖÇ ]+$");
    }
}