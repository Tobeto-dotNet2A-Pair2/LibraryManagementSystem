using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Queries.GetById;

public class GetByIdSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
}