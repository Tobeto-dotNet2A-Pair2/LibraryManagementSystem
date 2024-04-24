using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Create;

public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
{
    public CreatePaymentMethodCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
    }
}