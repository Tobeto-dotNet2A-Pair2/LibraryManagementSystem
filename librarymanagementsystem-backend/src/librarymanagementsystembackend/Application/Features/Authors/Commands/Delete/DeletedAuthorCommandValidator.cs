using FluentValidation;

namespace Application.Features.Authors.Commands.Delete;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}