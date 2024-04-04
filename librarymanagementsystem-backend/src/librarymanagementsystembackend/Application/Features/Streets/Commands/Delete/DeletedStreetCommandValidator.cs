using FluentValidation;

namespace Application.Features.Streets.Commands.Delete;

public class DeleteStreetCommandValidator : AbstractValidator<DeleteStreetCommand>
{
    public DeleteStreetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}