using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Create;

public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
{
    public CreatePaymentMethodCommandValidator()
    {
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.PaymentMethodName).NotEmpty().Length(2,50);
    }
}