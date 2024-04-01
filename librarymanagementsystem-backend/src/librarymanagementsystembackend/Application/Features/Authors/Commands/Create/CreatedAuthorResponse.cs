using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Commands.Create;

public class CreatedAuthorResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AuthorCountry { get; set; }
}