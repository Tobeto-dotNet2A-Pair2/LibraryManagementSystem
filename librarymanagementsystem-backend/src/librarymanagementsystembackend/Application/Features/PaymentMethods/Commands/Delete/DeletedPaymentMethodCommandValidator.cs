using FluentValidation;

namespace Application.Features.PaymentMethods.Commands.Delete;

public class DeletePaymentMethodCommandValidator : AbstractValidator<DeletePaymentMethodCommand>
{
    public DeletePaymentMethodCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}