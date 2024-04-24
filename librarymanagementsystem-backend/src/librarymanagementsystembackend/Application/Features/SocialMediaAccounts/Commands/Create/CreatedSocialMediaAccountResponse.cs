using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreatedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
}