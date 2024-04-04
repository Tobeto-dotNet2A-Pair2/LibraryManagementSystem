using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Create;

public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
{
    public CreatePaymentMethodCommandValidator()
    {
        RuleFor(c => c.BranchId).NotEmpty().Must(id => Guid.TryParse(id.ToString(), out _)); 
        RuleFor(c => c.PaymentMethodName).NotEmpty().Length(1, 50);
    }
}