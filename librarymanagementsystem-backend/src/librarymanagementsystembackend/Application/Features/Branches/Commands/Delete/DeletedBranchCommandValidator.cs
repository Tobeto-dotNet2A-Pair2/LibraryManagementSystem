using FluentValidation;

namespace Application.Features.Branches.Commands.Delete;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}