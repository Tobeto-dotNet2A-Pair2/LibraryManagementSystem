using FluentValidation;

namespace Application.Features.Libraries.Commands.Delete;

public class DeleteLibraryCommandValidator : AbstractValidator<DeleteLibraryCommand>
{
    public DeleteLibraryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}