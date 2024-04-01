using FluentValidation;

namespace Application.Features.Penalties.Commands.Delete;

public class DeletePenaltyCommandValidator : AbstractValidator<DeletePenaltyCommand>
{
    public DeletePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}