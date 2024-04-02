using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberContacts.Commands.Delete;

public class DeletedMemberContactResponse : IResponse
{
    public Guid Id { get; set; }
}