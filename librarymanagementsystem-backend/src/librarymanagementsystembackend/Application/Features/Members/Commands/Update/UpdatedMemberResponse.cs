using NArchitecture.Core.Application.Responses;

namespace Application.Features.Members.Commands.Update;

public class UpdatedMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TC { get; set; }
    public string PhoneNumber { get; set; }
    public string Photo { get; set; }
    public DateTime MemberShipDate { get; set; }
    public string? Position { get; set; }
    public string Reservation { get; set; }
    public string Messages { get; set; }
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public decimal TotalDebt { get; set; }
    public Guid UserId { get; set; }
}