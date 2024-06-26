using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SocialMediaAccountConfiguration : IEntityTypeConfiguration<SocialMediaAccount>
{
    public void Configure(EntityTypeBuilder<SocialMediaAccount> builder)
    {
        builder.ToTable("SocialMediaAccounts").HasKey(sma => sma.Id);

        builder.Property(sma => sma.Id).HasColumnName("Id").IsRequired();
        builder.Property(sma => sma.BranchId).HasColumnName("BranchId");
        builder.Property(sma => sma.Logo).HasColumnName("Logo");
        builder.Property(sma => sma.Url).HasColumnName("Url");
        builder.Property(sma => sma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sma => sma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sma => sma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sma => !sma.DeletedDate.HasValue);
    }
}