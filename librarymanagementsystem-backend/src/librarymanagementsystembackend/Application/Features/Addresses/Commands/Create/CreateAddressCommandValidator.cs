using FluentValidation;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.StreetId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 50);
        RuleFor(c => c.Description).Length(2, 50);
    }
}