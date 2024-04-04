using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
        RuleFor(c => c.TotalMaterialPenalty).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty().GreaterThan(0);
        RuleFor(c => c.BorrowedMaterialId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _));
    }
}