using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Create;

public class CreatedAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StreetId { get; set; }
    public string AddressName { get; set; }
    public string Description { get; set; }
}