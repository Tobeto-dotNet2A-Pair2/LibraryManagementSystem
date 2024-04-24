using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Create;

public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
{
    public CreatePaymentMethodCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(2, 50);
        RuleFor(c => c.BranchId).NotEmpty();
    }
}