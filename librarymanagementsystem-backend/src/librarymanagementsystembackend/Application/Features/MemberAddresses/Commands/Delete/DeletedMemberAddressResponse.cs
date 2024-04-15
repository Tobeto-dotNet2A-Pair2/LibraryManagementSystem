using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAddresses.Commands.Delete;

public class DeletedMemberAddressResponse : IResponse
{
    public Guid Id { get; set; }
}