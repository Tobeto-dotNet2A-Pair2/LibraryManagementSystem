using FluentValidation;

namespace Application.Features.Libraries.Commands.Update;

public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
{
    public UpdateLibraryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LibraryName).NotEmpty().Length(2, 100);
    }
}