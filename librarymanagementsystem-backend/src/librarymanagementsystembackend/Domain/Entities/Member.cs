using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Member:Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePicture { get; set; }
    public string? Position { get; set; }
    public decimal TotalDebt { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid UserId { get; set; }


    public Member() { }

    public Member(string firstName, string lastName, string nationalIdentity, DateTime birthDate, string phoneNumber, string? profilePicture, string? position, decimal totalDebt, bool isActive, Guid userId)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalIdentity = nationalIdentity;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        ProfilePicture = profilePicture;
        Position = position;
        TotalDebt = totalDebt;
        IsActive = isActive;
        UserId = userId;
    }

    public virtual User User { get; set; }
    public virtual ICollection<MemberAddress> MemberAddresses { get; set; }
    public virtual ICollection<MemberContact> MemberContacts { get; set; }
    public virtual ICollection<MemberNotification> MemberNotifications { get; set; }
    public virtual ICollection<BorrowedMaterial> BorrowedMaterials { get; set; }

    public virtual ICollection<FavoriteList> FavoriteLists { get; set; }


}
