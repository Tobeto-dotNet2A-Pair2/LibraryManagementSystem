using FluentValidation;

namespace Application.Features.Neighborhoods.Commands.Delete;

public class DeleteNeighborhoodCommandValidator : AbstractValidator<DeleteNeighborhoodCommand>
{
    public DeleteNeighborhoodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}