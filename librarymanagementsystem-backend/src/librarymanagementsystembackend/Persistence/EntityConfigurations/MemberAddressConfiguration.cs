using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MemberAddressConfiguration : IEntityTypeConfiguration<MemberAddress>
{
    public void Configure(EntityTypeBuilder<MemberAddress> builder)
    {
        builder.ToTable("MemberAddresses").HasKey(ma => ma.Id);

        builder.Property(ma => ma.Id).HasColumnName("Id").IsRequired();
        builder.Property(ma => ma.MemberId).HasColumnName("MemberId");
        builder.Property(ma => ma.AddressId).HasColumnName("AddressId");
        builder.Property(ma => ma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ma => ma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ma => ma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ma => ma.Address);
        builder.HasOne(ma => ma.Member);


        builder.HasQueryFilter(ma => !ma.DeletedDate.HasValue);
    }
}