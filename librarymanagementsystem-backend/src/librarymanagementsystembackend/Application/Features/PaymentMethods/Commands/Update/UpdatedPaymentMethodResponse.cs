using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentMethods.Commands.Update;

public class UpdatedPaymentMethodResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string PaymentMethodName { get; set; }
}