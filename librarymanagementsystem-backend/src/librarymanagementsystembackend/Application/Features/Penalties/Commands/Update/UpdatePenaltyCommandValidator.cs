using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TotalMaterialPenalty).NotEmpty();
        RuleFor(c => c.DayDelay).NotEmpty();
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
    }
}