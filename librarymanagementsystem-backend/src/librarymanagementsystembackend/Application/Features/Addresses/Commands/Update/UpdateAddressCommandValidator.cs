using FluentValidation;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StreetId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 50);
        RuleFor(c => c.Description).NotEmpty().Length(2, 50);
    }
}