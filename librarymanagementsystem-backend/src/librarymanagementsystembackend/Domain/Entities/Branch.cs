using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Branch : Entity<Guid>
{
    public string Name { get; set; }
    public DateTime WorkingHours { get; set; }
    public string PhoneNumber { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }

    public Branch() { }

    public Branch(string name, DateTime workingHours, string phoneNumber, string? webSiteUrl, Guid addressId, Guid libraryId)
    {
        Name = name;
        WorkingHours = workingHours;
        PhoneNumber = phoneNumber;
        WebSiteUrl = webSiteUrl;
        AddressId = addressId;
        LibraryId = libraryId;
    }

    public virtual Address Address { get; set; }
    public virtual Library Library { get; set; }

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public virtual ICollection<MaterialCopy> MaterialCopies { get; set; }



}

