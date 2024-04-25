using NArchitecture.Core.Application.Responses;

namespace Application.Features.Members.Commands.Create;

public class CreatedMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfilePicture { get; set; }
    public string? Position { get; set; }
    public decimal TotalDebt { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
}