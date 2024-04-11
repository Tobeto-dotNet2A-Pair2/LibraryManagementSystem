using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Update;

public class UpdatePaymentMethodCommandValidator : AbstractValidator<UpdatePaymentMethodCommand>
{
    public UpdatePaymentMethodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.PaymentMethodName).NotEmpty().Length(2, 50);
    }
}