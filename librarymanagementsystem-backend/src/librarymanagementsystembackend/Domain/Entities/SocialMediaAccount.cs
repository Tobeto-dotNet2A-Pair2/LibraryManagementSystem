using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SocialMediaAccount : Entity<Guid>
{
    public Guid BranchId { get; set; }
    public string SocialMediaAccountLogo { get; set; }
    public string? SocialMediaAccountUrl { get; set; }

    public virtual Branch Branch { get; set; }
}
