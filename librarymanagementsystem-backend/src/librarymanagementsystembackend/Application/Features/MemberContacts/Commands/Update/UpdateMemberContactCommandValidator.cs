using FluentValidation;

namespace Application.Features.MemberContacts.Commands.Update;

public class UpdateMemberContactCommandValidator : AbstractValidator<UpdateMemberContactCommand>
{
    public UpdateMemberContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AskLibrarianTopic).NotEmpty();
        RuleFor(c => c.AskLibrarianDescription).NotEmpty();
        RuleFor(c => c.Messages).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}