using FluentValidation;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.StreetId).NotEmpty();
        RuleFor(c => c.AddressName).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}