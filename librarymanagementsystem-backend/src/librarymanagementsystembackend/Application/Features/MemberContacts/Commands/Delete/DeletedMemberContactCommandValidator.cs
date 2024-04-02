using FluentValidation;

namespace Application.Features.MemberContacts.Commands.Delete;

public class DeleteMemberContactCommandValidator : AbstractValidator<DeleteMemberContactCommand>
{
    public DeleteMemberContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}