using FluentValidation;

namespace Application.Features.MemberContacts.Commands.Update;

public class UpdateMemberContactCommandValidator : AbstractValidator<UpdateMemberContactCommand>
{
    public UpdateMemberContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AskLibrarianTopic).NotEmpty().Length(2, 150);
        RuleFor(c => c.AskLibrarianDescription).NotEmpty().Length(2, 1000);
        RuleFor(c => c.Message).NotEmpty().Length(2, 1000);
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.LibraryId).NotEmpty();
    }
}