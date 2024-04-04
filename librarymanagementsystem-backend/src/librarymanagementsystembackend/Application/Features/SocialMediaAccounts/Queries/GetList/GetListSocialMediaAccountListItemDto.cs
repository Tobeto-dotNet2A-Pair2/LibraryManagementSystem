using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SocialMediaAccounts.Queries.GetList;

public class GetListSocialMediaAccountListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string SocialMediaAccountLogo { get; set; }
    public string? SocialMediaAccountUrl { get; set; }
}