using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class SocialMediaAccount : Entity<Guid>
{
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
    public SocialMediaAccount() { }

    public SocialMediaAccount(Guid branchId, string logo, string? url)
    {
        BranchId = branchId;
        Logo = logo;
        Url = url;
    }

    public virtual Branch Branch { get; set; }
}
