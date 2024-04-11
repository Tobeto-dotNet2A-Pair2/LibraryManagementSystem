using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TotalMaterialPenalty).NotEmpty().GreaterThan(0)
                   .When(c => c.TotalMaterialPenalty.HasValue);

        RuleFor(c => c.DayDelay).NotEmpty().GreaterThan(0);
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
    }
}