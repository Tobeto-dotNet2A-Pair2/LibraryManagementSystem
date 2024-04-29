using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAddresses.Commands.Update;

public class UpdatedMemberAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }
}