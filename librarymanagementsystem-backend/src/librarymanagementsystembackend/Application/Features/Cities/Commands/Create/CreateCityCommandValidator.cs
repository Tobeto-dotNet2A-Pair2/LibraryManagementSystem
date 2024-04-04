using FluentValidation;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.CityName).NotEmpty().Length(2,50).Matches("^[a-zA-ZðüþöçÐÜÞÝÖÇ]+$");
        //WithMessage("Þehir adý sadece harf içerebilir.");
    }
}