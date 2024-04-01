using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdatedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string SocialMediaAccountLogo { get; set; }
    public string? SocialMediaAccountUrl { get; set; }
}