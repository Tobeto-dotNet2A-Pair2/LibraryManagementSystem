using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Update;

public class UpdatePaymentMethodCommandValidator : AbstractValidator<UpdatePaymentMethodCommand>
{
    public UpdatePaymentMethodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); ;
        RuleFor(c => c.BranchId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)) ;
        RuleFor(c => c.PaymentMethodName).NotEmpty().Length(1, 50);
    }
}