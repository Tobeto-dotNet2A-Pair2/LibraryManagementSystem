using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentMethods.Commands.Delete;

public class DeletedPaymentMethodResponse : IResponse
{
    public Guid Id { get; set; }
}