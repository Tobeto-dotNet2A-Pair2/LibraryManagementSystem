using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdatedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
}