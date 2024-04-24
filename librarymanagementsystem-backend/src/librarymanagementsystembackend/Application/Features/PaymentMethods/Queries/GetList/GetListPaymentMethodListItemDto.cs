using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PaymentMethods.Queries.GetList;

public class GetListPaymentMethodListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BranchId { get; set; }
}