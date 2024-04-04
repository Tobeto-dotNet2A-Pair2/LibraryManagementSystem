using FluentValidation;

namespace Application.Features.Libraries.Commands.Update;

public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
{
    public UpdateLibraryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); 
        RuleFor(c => c.LibraryName).NotEmpty().Length(1, 100);
    }
}