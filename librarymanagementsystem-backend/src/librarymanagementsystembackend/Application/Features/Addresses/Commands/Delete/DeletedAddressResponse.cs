using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Delete;

public class DeletedAddressResponse : IResponse
{
    public Guid Id { get; set; }
}