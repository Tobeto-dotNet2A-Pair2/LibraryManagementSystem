using FluentValidation;

namespace Application.Features.Locations.Commands.Delete;

public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationCommand>
{
    public DeleteLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}