using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MemberContacts.Queries.GetList;

public class GetListMemberContactListItemDto : IDto
{
    public Guid Id { get; set; }
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public string Message { get; set; }
    public Guid MemberId { get; set; }
    public Guid LibraryId { get; set; }
}