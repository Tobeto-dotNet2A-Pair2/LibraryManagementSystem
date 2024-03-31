using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AmountPenalty).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty();
        RuleFor(c => c.FirstDayPunishment).NotEmpty();
        RuleFor(c => c.TotalPenalty).NotEmpty();
    }
}