using NArchitecture.Core.Application.Responses;

namespace Application.Features.Members.Queries.GetById;

public class GetByIdMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TC { get; set; }
    public string PhoneNumber { get; set; }
    public string Photo { get; set; }
    public string? Position { get; set; }
    public decimal TotalDebt { get; set; }
    public Guid UserId { get; set; }
}