using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAddresses.Queries.GetById;

public class GetByIdMemberAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }
}