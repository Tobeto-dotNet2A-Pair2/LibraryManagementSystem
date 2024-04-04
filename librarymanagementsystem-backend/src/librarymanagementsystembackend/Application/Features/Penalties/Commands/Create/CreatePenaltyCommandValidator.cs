using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.TotalMaterialPenalty).NotEmpty().GreaterThan(0)
                .When(c => c.TotalMaterialPenalty.HasValue);

        RuleFor(c => c.DayDelay).NotEmpty().GreaterThan(0);
        RuleFor(c => c.NotificationId).NotEmpty();
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
    }
}