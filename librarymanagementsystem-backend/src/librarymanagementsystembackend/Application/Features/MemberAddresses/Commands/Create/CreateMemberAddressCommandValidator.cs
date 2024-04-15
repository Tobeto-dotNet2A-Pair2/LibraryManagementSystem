using FluentValidation;

namespace Application.Features.MemberAddresses.Commands.Create;

public class CreateMemberAddressCommandValidator : AbstractValidator<CreateMemberAddressCommand>
{
    public CreateMemberAddressCommandValidator()
    {
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
    }
}