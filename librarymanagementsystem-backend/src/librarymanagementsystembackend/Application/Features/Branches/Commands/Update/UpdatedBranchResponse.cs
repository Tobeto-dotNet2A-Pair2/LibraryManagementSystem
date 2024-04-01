using NArchitecture.Core.Application.Responses;

namespace Application.Features.Branches.Commands.Update;

public class UpdatedBranchResponse : IResponse
{
    public Guid Id { get; set; }
    public string BranchName { get; set; }
    public DateTime WorkingHours { get; set; }
    public string Telephone { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }
}