using FluentValidation;

namespace Application.Features.Members.Commands.Update;

public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
{
    public UpdateMemberCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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