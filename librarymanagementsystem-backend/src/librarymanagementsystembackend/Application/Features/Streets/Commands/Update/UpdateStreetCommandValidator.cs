using FluentValidation;

namespace Application.Features.Streets.Commands.Update;

public class UpdateStreetCommandValidator : AbstractValidator<UpdateStreetCommand>
{
    public UpdateStreetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StreetName).NotEmpty().Length(2, 100).Matches("^[a-zA-Z?ü?öç?Ü??ÖÇ ]+$");
        RuleFor(c => c.NeighborhoodId).NotEmpty();
    }
}