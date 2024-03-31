using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.AmountPenalty).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty();
        RuleFor(c => c.FirstDayPunishment).NotEmpty();
        RuleFor(c => c.TotalPenalty).NotEmpty();
    }
}