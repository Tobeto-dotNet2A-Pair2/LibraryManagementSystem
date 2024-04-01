using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.TotalMaterialPenalty).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
    }
}