using FluentValidation;

namespace Application.Features.MemberContacts.Commands.Create;

public class CreateMemberContactCommandValidator : AbstractValidator<CreateMemberContactCommand>
{
    public CreateMemberContactCommandValidator()
    {
        RuleFor(c => c.AskLibrarianTopic).NotEmpty();
        RuleFor(c => c.AskLibrarianDescription).NotEmpty();
        RuleFor(c => c.Messages).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}