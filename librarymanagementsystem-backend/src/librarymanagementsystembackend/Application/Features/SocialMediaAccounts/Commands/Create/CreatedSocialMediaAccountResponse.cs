using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreatedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string SocialMediaAccountLogo { get; set; }
    public string? SocialMediaAccountUrl { get; set; }
}