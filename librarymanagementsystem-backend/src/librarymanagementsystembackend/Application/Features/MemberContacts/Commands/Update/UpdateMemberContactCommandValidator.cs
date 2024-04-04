using FluentValidation;

namespace Application.Features.MemberContacts.Commands.Update;

public class UpdateMemberContactCommandValidator : AbstractValidator<UpdateMemberContactCommand>
{
    public UpdateMemberContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AskLibrarianTopic).NotEmpty().MinimumLength(2).MaximumLength(150);
        RuleFor(c => c.AskLibrarianDescription).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(c => c.Messages).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(c => c.MemberId).NotEmpty();
    }
}