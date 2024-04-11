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
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.TotalDebt).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}