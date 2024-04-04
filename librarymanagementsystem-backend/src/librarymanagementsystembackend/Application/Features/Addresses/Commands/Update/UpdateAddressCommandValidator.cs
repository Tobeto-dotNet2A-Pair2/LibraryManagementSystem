using FluentValidation;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); ;
        RuleFor(c => c.StreetId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); 
        RuleFor(c => c.AddressName).NotEmpty().Length(1, 50); 
        RuleFor(c => c.Description).NotEmpty().Length(1, 200); 

       
    }
}