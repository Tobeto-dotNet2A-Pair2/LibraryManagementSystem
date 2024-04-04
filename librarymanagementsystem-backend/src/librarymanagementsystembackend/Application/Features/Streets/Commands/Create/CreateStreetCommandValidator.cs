using FluentValidation;

namespace Application.Features.Streets.Commands.Create;

public class CreateStreetCommandValidator : AbstractValidator<CreateStreetCommand>
{
    public CreateStreetCommandValidator()
    {
        RuleFor(c => c.StreetName).NotEmpty().Length(1, 100).Matches("^[a-zA-ZðüþöçÐÜÞÝÖÇ ]+$");
        RuleFor(c => c.NeighborhoodId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
    }
}