using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Branch : Entity<Guid>
{
   
    public string BranchName { get; set; }
    public DateTime WorkingHours { get; set; }
    public string Telephone { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }

    public virtual Address Address { get; set; }
    public virtual Library Library { get; set; }

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public virtual ICollection<MaterialCopy> MaterialCopies { get; set; }

    //todo: materialcopies  navigation property  yapılmadı


}

