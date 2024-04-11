using FluentValidation;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StreetId).NotEmpty();
        RuleFor(c => c.AddressName).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}