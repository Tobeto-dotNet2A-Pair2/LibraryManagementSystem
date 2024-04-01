using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Branches.Queries.GetList;

public class GetListBranchListItemDto : IDto
{
    public Guid Id { get; set; }
    public string BranchName { get; set; }
    public DateTime WorkingHours { get; set; }
    public string Telephone { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }
}