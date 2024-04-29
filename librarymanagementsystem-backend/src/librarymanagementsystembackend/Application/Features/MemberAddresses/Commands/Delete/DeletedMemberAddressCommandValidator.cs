using FluentValidation;

namespace Application.Features.MemberAddresses.Commands.Delete;

public class DeleteMemberAddressCommandValidator : AbstractValidator<DeleteMemberAddressCommand>
{
    public DeleteMemberAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}