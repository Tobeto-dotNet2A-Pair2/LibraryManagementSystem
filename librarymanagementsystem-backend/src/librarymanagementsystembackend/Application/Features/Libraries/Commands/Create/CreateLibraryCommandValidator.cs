using FluentValidation;

namespace Application.Features.Libraries.Commands.Create;

public class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
{
    public CreateLibraryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}