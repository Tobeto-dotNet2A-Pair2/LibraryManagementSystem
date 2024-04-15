using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.FirstName).HasColumnName("FirstName");
        builder.Property(m => m.LastName).HasColumnName("LastName");
        builder.Property(m => m.TC).HasColumnName("TC");
        builder.Property(m => m.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(m => m.Photo).HasColumnName("Photo");
        builder.Property(m => m.Position).HasColumnName("Position");
        builder.Property(m => m.TotalDebt).HasColumnName("TotalDebt").HasPrecision(18,2);
        builder.Property(m => m.UserId).HasColumnName("UserId");
        builder.Property(m => m.isActive).HasColumnName("isActive");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(m => m.User);
        builder.HasMany(m => m.MemberAddresses);
        builder.HasMany(m => m.MemberNotifications);
        builder.HasMany(m => m.BorrowedMaterials);
        builder.HasMany(m => m.FavoriteLists);
        builder.HasMany(m => m.MemberContacts);


        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}