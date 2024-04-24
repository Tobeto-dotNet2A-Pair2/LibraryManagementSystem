using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberContacts.Commands.Update;

public class UpdatedMemberContactResponse : IResponse
{
    public Guid Id { get; set; }
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public string Message { get; set; }
    public Guid MemberId { get; set; }
    public Guid LibraryId { get; set; }
}