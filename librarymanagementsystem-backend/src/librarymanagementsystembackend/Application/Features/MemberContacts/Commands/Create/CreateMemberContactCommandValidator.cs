using FluentValidation;

namespace Application.Features.MemberContacts.Commands.Create;

public class CreateMemberContactCommandValidator : AbstractValidator<CreateMemberContactCommand>
{
    public CreateMemberContactCommandValidator()
    {
        RuleFor(c => c.AskLibrarianTopic).NotEmpty();
        RuleFor(c => c.AskLibrarianDescription).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.LibraryId).NotEmpty();
    }
}