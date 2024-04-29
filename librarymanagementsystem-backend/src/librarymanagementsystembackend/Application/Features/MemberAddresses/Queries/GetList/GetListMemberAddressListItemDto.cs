using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MemberAddresses.Queries.GetList;

public class GetListMemberAddressListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }
}