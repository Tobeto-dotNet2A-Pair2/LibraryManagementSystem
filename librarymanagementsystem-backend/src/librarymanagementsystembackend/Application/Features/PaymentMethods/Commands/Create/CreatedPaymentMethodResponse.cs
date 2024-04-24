using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentMethods.Commands.Create;

public class CreatedPaymentMethodResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BranchId { get; set; }
}