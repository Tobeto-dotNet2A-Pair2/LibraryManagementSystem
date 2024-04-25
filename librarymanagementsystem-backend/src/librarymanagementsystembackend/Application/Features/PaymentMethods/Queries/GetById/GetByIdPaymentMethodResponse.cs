using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentMethods.Queries.GetById;

public class GetByIdPaymentMethodResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BranchId { get; set; }
}