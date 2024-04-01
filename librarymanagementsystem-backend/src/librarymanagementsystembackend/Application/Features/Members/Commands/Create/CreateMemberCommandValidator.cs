using FluentValidation;

namespace Application.Features.Members.Commands.Create;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.TC).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.Photograph).NotEmpty();
        RuleFor(c => c.MemberShipDate).NotEmpty();
        RuleFor(c => c.Reservation).NotEmpty();
        RuleFor(c => c.Messages).NotEmpty();
        RuleFor(c => c.AskLibrarianTopic).NotEmpty();
        RuleFor(c => c.AskLibrarianDescription).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}