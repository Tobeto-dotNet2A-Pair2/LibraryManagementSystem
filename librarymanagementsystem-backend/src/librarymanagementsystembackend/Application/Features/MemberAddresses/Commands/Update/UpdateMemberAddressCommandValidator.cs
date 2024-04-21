using FluentValidation;

namespace Application.Features.MemberAddresses.Commands.Update;

public class UpdateMemberAddressCommandValidator : AbstractValidator<UpdateMemberAddressCommand>
{
    public UpdateMemberAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
    }
}