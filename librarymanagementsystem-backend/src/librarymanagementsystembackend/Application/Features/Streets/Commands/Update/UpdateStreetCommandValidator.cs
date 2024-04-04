using FluentValidation;

namespace Application.Features.Streets.Commands.Update;

public class UpdateStreetCommandValidator : AbstractValidator<UpdateStreetCommand>
{
    public UpdateStreetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
        RuleFor(c => c.StreetName).NotEmpty().Length(1, 100).Matches("^[a-zA-ZðüþöçÐÜÞÝÖÇ ]+$");
        RuleFor(c => c.NeighborhoodId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
    }
}