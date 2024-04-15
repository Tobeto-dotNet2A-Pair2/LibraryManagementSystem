using FluentValidation;

namespace Application.Features.Libraries.Commands.Create;

public class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
{
    public CreateLibraryCommandValidator()
    {
        RuleFor(c => c.LibraryName).NotEmpty().Length(2, 100);
    }
}