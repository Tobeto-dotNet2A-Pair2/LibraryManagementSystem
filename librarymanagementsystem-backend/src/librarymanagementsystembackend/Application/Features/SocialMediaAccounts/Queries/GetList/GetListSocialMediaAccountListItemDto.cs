using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SocialMediaAccounts.Queries.GetList;

public class GetListSocialMediaAccountListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
}