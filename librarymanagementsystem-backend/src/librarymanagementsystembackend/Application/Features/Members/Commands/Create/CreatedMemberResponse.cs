using NArchitecture.Core.Application.Responses;

namespace Application.Features.Members.Commands.Create;

public class CreatedMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TC { get; set; }
    public string PhoneNumber { get; set; }
    public string Photograph { get; set; }
    public DateTime MemberShipDate { get; set; }
    public string Reservation { get; set; }
    public string Messages { get; set; }
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public Guid UserId { get; set; }
}