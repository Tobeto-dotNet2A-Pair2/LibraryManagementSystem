using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Addresses.Queries.GetList;

public class GetListAddressListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StreetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}