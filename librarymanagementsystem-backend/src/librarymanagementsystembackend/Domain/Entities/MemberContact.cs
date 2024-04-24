using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class MemberContact : Entity<Guid>
{
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public string Message { get; set; }
    public Guid MemberId { get; set; }
    public Guid LibraryId { get; set; }

    public MemberContact() { }
    public MemberContact(string askLibrarianTopic, string askLibrarianDescription, string message, Guid memberId, Guid libraryId)
    {
        AskLibrarianTopic = askLibrarianTopic;
        AskLibrarianDescription = askLibrarianDescription;
        Message = message;
        MemberId = memberId;
        LibraryId = libraryId;
    }

    public virtual Member Member { get; set; }
    public virtual Library Library { get; set; }
}
