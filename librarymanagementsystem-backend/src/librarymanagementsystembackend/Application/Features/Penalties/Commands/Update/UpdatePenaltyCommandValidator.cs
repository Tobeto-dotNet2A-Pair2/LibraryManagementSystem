using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TotalMaterialDebt).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty().GreaterThan(0);
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
    }
}