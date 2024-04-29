using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.TotalMaterialDebt).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty().GreaterThan(0);
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
    }
}