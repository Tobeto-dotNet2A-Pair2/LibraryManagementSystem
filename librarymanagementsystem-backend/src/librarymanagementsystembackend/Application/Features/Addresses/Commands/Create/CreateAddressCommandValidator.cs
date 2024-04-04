using FluentValidation;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.StreetId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); 
        RuleFor(c => c.AddressName).NotEmpty().Length(1,50);
        RuleFor(c => c.Description).NotEmpty().Length(1,200); 
    }
}