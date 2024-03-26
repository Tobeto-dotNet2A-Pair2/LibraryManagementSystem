using FluentValidation;

namespace Application.Features.Members.Commands.Delete;

public class DeleteMemberCommandValidator : AbstractValidator<DeleteMemberCommand>
{
    public DeleteMemberCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}