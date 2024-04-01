using NArchitecture.Core.Application.Responses;

namespace Application.Features.Branches.Commands.Create;

public class CreatedBranchResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LibraryId { get; set; }
    public string BranchName { get; set; }
    public DateTime WorkingHours { get; set; }
    public string Telephone { get; set; }
    public string? WebSiteUrl { get; set; }
}